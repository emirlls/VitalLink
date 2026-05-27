using VitalLink.Entities.Users;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Users;

public class EfUserProfileRepository : EfBaseRepository<UserProfile>, IUserProfileRepository
{
    public EfUserProfileRepository(IDbContextProvider<VitalLinkDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}