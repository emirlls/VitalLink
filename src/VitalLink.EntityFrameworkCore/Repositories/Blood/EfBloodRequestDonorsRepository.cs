using VitalLink.Entities.Bloods;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Blood;

public class EfBloodRequestDonorsRepository : EfBaseRepository<BloodRequestDonors>, IBloodRequestDonorsRepository
{
    public EfBloodRequestDonorsRepository(IDbContextProvider<VitalLinkDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}