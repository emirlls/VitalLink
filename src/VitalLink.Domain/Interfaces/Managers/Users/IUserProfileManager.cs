using VitalLink.Entities.Users;
using VitalLink.Models.Users;

namespace VitalLink.Interfaces.Managers.Users;

public interface IUserProfileManager : IBaseDomainService<UserProfile>
{
    UserProfile Update(
        UserProfile userProfile,
        UserProfileUpdateModel updateModel
    );
}