using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VitalLink.Constants;
using VitalLink.Etos;
using VitalLink.Extensions;
using VitalLink.Hubs;
using VitalLink.Interfaces.Managers;
using VitalLink.Interfaces.Managers.Bloods;
using VitalLink.Models.Bloods;
using VitalLink.Repositories.Users;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace VitalLink.Handlers;

public class BloodRequestCreateEventHandler : IDistributedEventHandler<BloodRequestCreateEto>, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IHubContext<BloodRequestHub> _hubContext;

    public BloodRequestCreateEventHandler(
        IServiceProvider serviceProvider,
        IHubContext<BloodRequestHub> hubContext
    )
    {
        _serviceProvider = serviceProvider;
        _hubContext = hubContext;
    }

    public async Task HandleEventAsync(BloodRequestCreateEto eventData)
    {
        var bloodRequestManager = _serviceProvider.GetRequiredService<IBloodRequestManager>();
        var bloodRequest = await bloodRequestManager.TryGetByQueryableAsync(q =>
                q
                    .Where(x => x.Id.Equals(eventData.BloodRequestId))
                    .Include(x => x.IdentityUser),
            throwIfNull: true
        );

        var userProfileRepository = _serviceProvider.GetRequiredService<IUserProfileRepository>();
        var usersInRange = await userProfileRepository.TryGetListQueryableAsync(q =>
            q
                .Where(x => x.BloodTypeId.Equals(bloodRequest.BloodTypeId))
                .Where(x => x.Geom.Distance(bloodRequest.Geom) <= x.Radius)
        );
        var userIds = usersInRange
            .Select(x => x.UserId)
            .Select(x => x.ToString())
            .ToList();

        var model = new BloodRequestCreatedEventModel
        {
            Id = bloodRequest.Id,
            CreatorId = bloodRequest.CreatorId,
            BloodTypeId = bloodRequest.BloodTypeId,
            Name = bloodRequest.IdentityUser.Name,
            Surname = bloodRequest.IdentityUser.Surname,
            GeoJson = bloodRequest.Geom.ToGeoJson(),
            CreationTime = bloodRequest.CreationTime
        };

        await _hubContext
            .Clients
            .Users(userIds)
            .SendAsync(HubConstants.Methods.BloodRequestCreate,
                model);
    }
}