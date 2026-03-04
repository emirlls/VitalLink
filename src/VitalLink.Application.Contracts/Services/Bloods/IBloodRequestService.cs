using System;
using System.Threading;
using System.Threading.Tasks;
using VitalLink.Dtos;
using VitalLink.Dtos.Bloods;
using Volo.Abp.Application.Services;

namespace VitalLink.Services.Bloods;

public interface IBloodRequestService : IApplicationService
{
    Task<bool> CreateAsync(
        BloodRequestDto bloodRequestDto,
        CancellationToken cancellationToken = default
    );
    Task<bool> UpdateAsync(
        Guid id,
        BloodRequestDto bloodRequestDto,
        CancellationToken cancellationToken = default
    );
    Task<bool> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );
}