using System;
using System.Threading;
using System.Threading.Tasks;
using VitalLink.Dtos.Users;
using Volo.Abp.Application.Services;

namespace VitalLink.Services.Users;

public interface IUserService : IApplicationService
{
    Task<UserProfileDto> GetUserProfileAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    );

    Task<UserProfileDto> UpdateUserProfileAsync(
        Guid userId,
        UserProfileUpdateDto userProfileUpdateDto,
        CancellationToken cancellationToken = default
    );
}