using VitalLink.Entities.Lookups;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Lookups;

public class EfBloodRequestStatusRepository : EfBaseRepository<BloodRequestStatus>, IBloodRequestStatusRepository
{
    public EfBloodRequestStatusRepository(IDbContextProvider<VitalLinkDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}