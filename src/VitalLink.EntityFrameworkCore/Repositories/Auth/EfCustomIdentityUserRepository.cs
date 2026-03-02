using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace VitalLink.Repositories.Auth;

public class EfCustomIdentityUserRepository : EfBaseRepository<IdentityUser>, ICustomIdentityUserRepository
{
    public EfCustomIdentityUserRepository(IDbContextProvider<VitalLinkDbContext> dbContextProvider) : 
        base(dbContextProvider)
    {
    }
}