using System;
using System.Threading;
using System.Threading.Tasks;
using VitalLink.Dtos.Bloods;
using VitalLink.Filtering.Bloods;
using Volo.Abp.Application.Dtos;
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

    Task<PagedResultDto<BloodRequestListDto>> GetSuitableAllFilteredAsync(
        BloodRequestFilters bloodRequestFilters,
        CancellationToken cancellationToken
    );

    Task<bool> CreateDonorRequestAsync(
        Guid bloodRequestId,
        CancellationToken cancellationToken = default
    );
    Task<bool> AcceptDonorRequestAsync(
        Guid bloodRequestDonorId,
        CancellationToken cancellationToken = default
    );

    Task<bool> CloseRequestAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task<PagedResultDto<BloodRequestListDto>> GetAllFilteredAsync(
        BloodRequestFilters bloodRequestFilters, 
        CancellationToken cancellationToken = default
    );
}