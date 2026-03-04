using Microsoft.Extensions.Localization;
using VitalLink.Constants;
using VitalLink.Entities.Users;
using VitalLink.Interfaces.Managers.Users;
using VitalLink.Localization;
using VitalLink.Models.Users;
using VitalLink.Repositories.Base;

namespace VitalLink.Managers.Users;

public class UserProfileManager : BaseDomainService<UserProfile>, IUserProfileManager
{
    public UserProfileManager(IBaseRepository<UserProfile> baseRepository,
        IStringLocalizer<VitalLinkResource> stringLocalizer
        ) : base(
        baseRepository,
        stringLocalizer,
        ExceptionCodes.UserProfile.NotFound,
        ExceptionCodes.UserProfile.AlreadyExists
    )
    {
    }

    public UserProfile Update(UserProfile userProfile, UserProfileUpdateModel updateModel)
    {
        userProfile.BloodTypeId = updateModel.BloodTypeId;
        userProfile.Radius = updateModel.Radius;
        userProfile.Geom = updateModel.Geom;

        return userProfile;
    }
}