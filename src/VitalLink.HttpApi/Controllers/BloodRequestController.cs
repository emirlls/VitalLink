using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitalLink.Dtos;
using VitalLink.Dtos.Bloods;
using VitalLink.Services;
using VitalLink.Services.Bloods;
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