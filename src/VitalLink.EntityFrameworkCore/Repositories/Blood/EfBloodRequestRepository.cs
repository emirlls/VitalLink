using VitalLink.Entities;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Blood;

public class EfBloodRequestRepository : EfBaseRepository<BloodRequest>, IBloodRequestRepository
{
    public EfBloodRequestRepository(IDbContextProvider<VitalLinkDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}