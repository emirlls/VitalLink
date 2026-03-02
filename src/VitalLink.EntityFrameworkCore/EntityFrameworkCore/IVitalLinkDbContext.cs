using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.EntityFrameworkCore;

[ConnectionStringName(VitalLinkDbProperties.ConnectionStringName)]
public interface IVitalLinkDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
