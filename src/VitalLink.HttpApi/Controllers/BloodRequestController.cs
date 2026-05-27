using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitalLink.Dtos.Bloods;
using VitalLink.Filtering.Bloods;
using VitalLink.Services.Bloods;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Controllers;

[ApiController]
[Route("blood-requests")]
[Authorize]
public class BloodRequestController : VitalLinkController
{
    private readonly IAbpLazyServiceProvider _abpLazyServiceProvider;

    private IBloodRequestService BloodRequestService
        => _abpLazyServiceProvider.LazyGetRequiredService<IBloodRequestService>();

    public BloodRequestController(IAbpLazyServiceProvider abpLazyServiceProvider)
    {
        _abpLazyServiceProvider = abpLazyServiceProvider;
    }

    /// <summary>
    /// Use to create new blood request.
    /// </summary>
    /// <param name="bloodRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> CreateAsync(
        BloodRequestDto bloodRequest,
        CancellationToken cancellationToken = default
    ) => await BloodRequestService.CreateAsync(
        bloodRequest,
        cancellationToken
    );
    
    /// <summary>
    /// Use to became a donor.
    /// </summary>
    /// <param name="bloodRequestId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("{bloodRequestId}")]
    public async Task<bool> CreateDonorRequestAsync(
        Guid bloodRequestId,
        CancellationToken cancellationToken = default
    ) => await BloodRequestService.CreateDonorRequestAsync(
        bloodRequestId,
        cancellationToken
    );

    /// <summary>
    /// Use to accept donor request.
    /// </summary>
    /// <param name="bloodRequestDonorId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("{bloodRequestDonorId}/accept")]
    public async Task<bool> AcceptDonorRequestAsync(
        Guid bloodRequestDonorId,
        CancellationToken cancellationToken = default
    ) => await BloodRequestService.AcceptDonorRequestAsync(
        bloodRequestDonorId,
        cancellationToken
    );
    
    /// <summary>
    /// Use to all blood requests of current user. 
    /// </summary>
    /// <param name="bloodRequestFilters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedResultDto<BloodRequestListDto>> GetAllFilteredAsync(
        [FromQuery]BloodRequestFilters bloodRequestFilters,
        CancellationToken cancellationToken = default
    ) => await BloodRequestService
        .GetAllFilteredAsync(
            bloodRequestFilters,
            cancellationToken
        );
    /// <summary>
    /// Use to get suitable blood requests.
    /// </summary>
    /// <param name="bloodRequestFilters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("suitables")]
    public async Task<PagedResultDto<BloodRequestListDto>> GetSuitableAllFilteredAsync(
        [FromQuery]BloodRequestFilters bloodRequestFilters,
        CancellationToken cancellationToken = default
        ) => await BloodRequestService
        .GetSuitableAllFilteredAsync(
            bloodRequestFilters,
            cancellationToken
        );
    
    /// <summary>
    /// Use to update blood request.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="bloodRequestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<bool> UpdateAsync(
        Guid id,
        BloodRequestDto bloodRequestDto,
        CancellationToken cancellationToken = default
    ) => await BloodRequestService.UpdateAsync(
        id,
        bloodRequestDto,
        cancellationToken
    );
    
    /// <summary>
    /// Use to close blood request.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<bool> CloseRequestAsync(
        Guid id,
        CancellationToken cancellationToken = default
    ) => await BloodRequestService.CloseRequestAsync(
        id,
        cancellationToken
    );
    
    /// <summary>
    /// Use to delete blood request.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default
    ) => await BloodRequestService.DeleteAsync(
        id,
        cancellationToken
    );
}