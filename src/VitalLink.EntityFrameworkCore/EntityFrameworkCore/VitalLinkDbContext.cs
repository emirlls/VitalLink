using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.EntityFrameworkCore;

[ConnectionStringName(VitalLinkDbProperties.ConnectionStringName)]
public class VitalLinkDbContext : AbpDbContext<VitalLinkDbContext>, IVitalLinkDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public VitalLinkDbContext(DbContextOptions<VitalLinkDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureVitalLink();
    }
}
