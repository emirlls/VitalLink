using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VitalLink.Constants;
using VitalLink.Etos;
using VitalLink.Hubs;
using VitalLink.Models.Bloods;
using VitalLink.Repositories.Blood;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace VitalLink.Handlers;

public class BloodRequestDonorRequestEventHandler : IDistributedEventHandler<BloodRequestDonorRequestEto>,
    ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public BloodRequestDonorRequestEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleEventAsync(BloodRequestDonorRequestEto eventData)
    {
        var bloodRequestDonorRepository = _serviceProvider.GetRequiredService<IBloodRequestDonorsRepository>();
        var hubContext = _serviceProvider.GetRequiredService<IHubContext<BloodRequestDonorHub>>();
        var bloodRequestDonor = await bloodRequestDonorRepository.TryGetByQueryableAsync(q =>
            q
                .Where(x => x.Id.Equals(eventData.Id))
                .Include(x => x.BloodRequest)
                .Include(x => x.IdentityUser)
        );
        var model = new BloodRequestDonorRequestModel
        {
            Id = bloodRequestDonor.Id,
            UserId = bloodRequestDonor.UserId,
            UserName = bloodRequestDonor.IdentityUser.Name,
            UserSurname = bloodRequestDonor.IdentityUser.Surname,
            BloodRequestNumber = bloodRequestDonor.BloodRequest.Number,
            RequestDate = bloodRequestDonor.CreationTime
        };
        var bloodRequestCreatorId = bloodRequestDonor.BloodRequest.CreatorId.GetValueOrDefault().ToString();
        await hubContext
            .Clients
            .User(bloodRequestCreatorId)
            .SendAsync(
                HubConstants.Methods.BloodRequestDonorCreate,
                model
            );
    }
}