using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;
using IdentityRole = Volo.Abp.Identity.IdentityRole;

namespace VitalLink.Repositories.Auth;

public class EfCustomRoleRepository : EfBaseRepository<IdentityRole>, ICustomRoleRepository
{
    public EfCustomRoleRepository(IDbContextProvider<VitalLinkDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}