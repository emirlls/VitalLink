using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VitalLink.Dtos.Users;
using VitalLink.Interfaces.Managers.Users;
using VitalLink.Mappers.Users;
using VitalLink.Repositories.Users;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace VitalLink.Services.Users;

public class UserService : ApplicationService, IUserService
{
    private IUserProfileManager UserProfileManager =>
        LazyServiceProvider.LazyGetRequiredService<IUserProfileManager>();

    private IUserProfileRepository UserProfileRepository =>
        LazyServiceProvider.LazyGetRequiredService<IUserProfileRepository>();

    private readonly UserProfileMapper _userProfileMapper;

    public UserService(UserProfileMapper userProfileMapper)
    {
        _userProfileMapper = userProfileMapper;
    }

    public async Task<UserProfileDto> GetUserProfileAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        var userProfile = await UserProfileManager.TryGetByQueryableAsync(q =>
                q.Where(x => x.UserId.Equals(userId))
                    .Include(x => x.BloodType),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );
        var userProfileDto = _userProfileMapper.MapToDto(userProfile);
        return userProfileDto;
    }

    public async Task<UserProfileDto> CreateUserProfileAsync(
        UserProfileCreateDto userProfileCreateDto,
        CancellationToken cancellationToken = default
    )
    {
        var model = _userProfileMapper.MapToModel(userProfileCreateDto);
        var entity = UserProfileManager.Create(
            model,
            CurrentUser.GetId()
        );
        await UserProfileRepository.InsertAsync(entity, cancellationToken: cancellationToken);
        var userProfileDto = _userProfileMapper.MapToDto(entity);
        return userProfileDto;
    }

    public async Task<UserProfileDto> UpdateUserProfileAsync(
        Guid userId,
        UserProfileCreateDto userProfileCreateDto,
        CancellationToken cancellationToken = default
    )
    {
        var userProfile = await UserProfileManager.TryGetByQueryableAsync(q =>
                q.Where(x => x.UserId.Equals(userId))
                    .Include(x => x.BloodType),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );
        var updateModel = _userProfileMapper.MapToModel(userProfileCreateDto);
        var updatedEntity = UserProfileManager.Update(userProfile, updateModel);

        await UserProfileRepository.UpdateAsync(
            updatedEntity,
            autoSave: true,
            cancellationToken: cancellationToken);

        var userProfileDto = _userProfileMapper.MapToDto(userProfile);
        return userProfileDto;
    }
}