using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitalLink.Dtos.Users;
using VitalLink.Services.Users;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Controllers;

[Authorize]
[ApiController]
[Route("users")]
public class UserController : VitalLinkController
{
    private readonly IAbpLazyServiceProvider  _lazyServiceProvider;
    private IUserService UserService => _lazyServiceProvider.LazyGetRequiredService<IUserService>();
    
    public UserController(IAbpLazyServiceProvider lazyServiceProvider)
    {
        _lazyServiceProvider = lazyServiceProvider;
    }
    
    /// <summary>
    /// Use to get user profile.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    public async Task<UserProfileDto> GetUserProfileAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    ) => await UserService.GetUserProfileAsync(
        userId,
        cancellationToken
    );
    
    /// <summary>
    /// Use to update user profile.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userProfileUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{userId}")]
    public async Task<UserProfileDto> UpdateUserProfileAsync(
        Guid userId,
        UserProfileUpdateDto userProfileUpdateDto,
        CancellationToken cancellationToken = default
    ) => await UserService.UpdateUserProfileAsync(
        userId,
        userProfileUpdateDto,
        cancellationToken
    );

}