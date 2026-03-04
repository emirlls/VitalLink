using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VitalLink.Constants;
using VitalLink.Dtos.Bloods;
using VitalLink.Etos;
using VitalLink.Filtering.Bloods;
using VitalLink.Interfaces.Managers.Bloods;
using VitalLink.Interfaces.Managers.Users;
using VitalLink.Repositories.Blood;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Users;
using BloodRequestMapper = VitalLink.Mappers.Bloods.BloodRequestMapper;

namespace VitalLink.Services.Bloods;

public class BloodRequestService : ApplicationService, IBloodRequestService
{
    private readonly BloodRequestMapper _bloodRequestMapper;

    private IBloodRequestManager BloodRequestManager =>
        LazyServiceProvider.LazyGetRequiredService<IBloodRequestManager>();

    private IBloodRequestRepository BloodRequestRepository =>
        LazyServiceProvider.LazyGetRequiredService<IBloodRequestRepository>();

    private IUserProfileManager UserProfileManager =>
        LazyServiceProvider.LazyGetRequiredService<IUserProfileManager>();

    private IBloodRequestDonorsManager BloodRequestDonorsManager =>
        LazyServiceProvider.LazyGetRequiredService<IBloodRequestDonorsManager>();

    private IBloodRequestDonorsRepository BloodRequestDonorsRepository =>
        LazyServiceProvider.LazyGetRequiredService<IBloodRequestDonorsRepository>();

    private IDistributedEventBus DistributedEventBus =>
        LazyServiceProvider.LazyGetRequiredService<IDistributedEventBus>();

    public BloodRequestService(BloodRequestMapper bloodRequestMapper)
    {
        _bloodRequestMapper = bloodRequestMapper;
    }

    public async Task<bool> CreateAsync(
        BloodRequestDto bloodRequestDto,
        CancellationToken cancellationToken = default
    )
    {
        var bloodRequestModel = _bloodRequestMapper.MapToModel(bloodRequestDto);
        var entity = BloodRequestManager.Create(
            bloodRequestModel,
            CurrentUser.GetId()
        );
        await BloodRequestRepository.InsertAsync(entity, cancellationToken: cancellationToken);
        var bloodRequestCreateEto = new BloodRequestCreateEto
        {
            BloodRequestId = entity.Id
        };
        await DistributedEventBus.PublishAsync(bloodRequestCreateEto);
        return true;
    }

    public async Task<bool> UpdateAsync(
        Guid id,
        BloodRequestDto bloodRequestDto,
        CancellationToken cancellationToken = default
    )
    {
        var entity = await BloodRequestManager.TryGetByAsync(x => x.Id.Equals(id),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );
        var bloodRequestModel = _bloodRequestMapper.MapToModel(bloodRequestDto);
        var updatedEntity = BloodRequestManager.Update(
            entity,
            bloodRequestModel
        );
        await BloodRequestRepository.UpdateAsync(
            updatedEntity,
            cancellationToken: cancellationToken
        );
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await BloodRequestManager.TryGetByAsync(x => x.Id.Equals(id),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );
        await BloodRequestRepository.DeleteAsync(entity, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<PagedResultDto<BloodRequestListDto>> GetSuitableAllFilteredAsync(
        BloodRequestFilters bloodRequestFilters,
        CancellationToken cancellationToken = default
    )
    {
        var userProfile = await UserProfileManager.TryGetByAsync(x =>
                x.UserId.Equals(CurrentUser.GetId()),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );
        var completedStatusId = Guid.Parse(LookupSeederConstants.BloodRequestStatusConstants.Completed.Id);
        var bloodRequests = await BloodRequestRepository.GetDynamicListAsync(
            bloodRequestFilters, q =>
                q
                    .Where(x => x.StatusId != completedStatusId)
                    .Where(x => x.BloodTypeId.Equals(userProfile.BloodTypeId))
                    .Where(x => x.Geom.Distance(userProfile.Geom) <= userProfile.Radius),
            asNoTracking: true,
            cancellationToken: cancellationToken
        );
        var count = await BloodRequestRepository.GetDynamicListCountAsync(
            bloodRequestFilters,
            null,
            useCache: true, cancellationToken: cancellationToken);
        var dto = _bloodRequestMapper.MapToDto(bloodRequests);
        var response = new PagedResultDto<BloodRequestListDto>
        {
            Items = dto,
            TotalCount = count
        };
        return response;
    }

    public async Task<bool> CreateDonorRequestAsync(
        Guid bloodRequestId,
        CancellationToken cancellationToken = default
    )
    {
        await BloodRequestManager.TryGetByAsync(x =>
                x.Id.Equals(bloodRequestId),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );

        var bloodRequestDonor = BloodRequestDonorsManager.Create(bloodRequestId, CurrentUser.GetId());
        await BloodRequestDonorsRepository.InsertAsync(
            bloodRequestDonor,
            cancellationToken: cancellationToken
        );

        return true;
    }

    public async Task<bool> AcceptDonorRequestAsync(
        Guid bloodRequestDonorId,
        CancellationToken cancellationToken = default
    )
    {
        var bloodRequestDonor =
            await BloodRequestDonorsManager.TryGetByAsync(x =>
                    x.Id.Equals(bloodRequestDonorId),
                throwIfNull: true,
                cancellationToken: cancellationToken
            );

        BloodRequestDonorsManager.Accept(bloodRequestDonor);
        await BloodRequestDonorsRepository.UpdateAsync(
            bloodRequestDonor,
            cancellationToken: cancellationToken
        );

        return true;
    }

    public async Task<bool> CloseRequestAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var bloodRequest = await BloodRequestManager.TryGetByAsync(x => x.Id.Equals(id),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );
        BloodRequestManager.Close(bloodRequest);
        await BloodRequestRepository.UpdateAsync(
            bloodRequest,
            cancellationToken: cancellationToken
        );
        return true;
    }

    public async Task<PagedResultDto<BloodRequestListDto>> GetAllFilteredAsync(
        BloodRequestFilters bloodRequestFilters,
        CancellationToken cancellationToken = default
    )
    {
        var bloodRequests = await BloodRequestRepository.GetDynamicListAsync(
            bloodRequestFilters, q =>
                q
                    .Where(x => x.CreatorId.Equals(CurrentUser.GetId())),
            asNoTracking: true,
            cancellationToken: cancellationToken
        );
        var count = await BloodRequestRepository.GetDynamicListCountAsync(
            bloodRequestFilters,
            null,
            useCache: true, cancellationToken: cancellationToken);
        var dto = _bloodRequestMapper.MapToDto(bloodRequests);
        var response = new PagedResultDto<BloodRequestListDto>
        {
            Items = dto,
            TotalCount = count
        };
        return response;
    }
}