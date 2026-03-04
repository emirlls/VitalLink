using System;
using System.Threading;
using System.Threading.Tasks;
using VitalLink.Dtos;
using VitalLink.Dtos.Bloods;
using VitalLink.Etos;
using VitalLink.Interfaces.Managers.Bloods;
using VitalLink.Mappers;
using VitalLink.Repositories.Blood;
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
        await  BloodRequestRepository.DeleteAsync(entity, cancellationToken: cancellationToken);
        return true;
    }
}