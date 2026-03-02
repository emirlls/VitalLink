using VitalLink.Entities.Lookups;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Lookups;

public class EfBloodTypeRepository : EfBaseRepository<BloodType>, IBloodTypeRepository
{
    public EfBloodTypeRepository(IDbContextProvider<VitalLinkDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}