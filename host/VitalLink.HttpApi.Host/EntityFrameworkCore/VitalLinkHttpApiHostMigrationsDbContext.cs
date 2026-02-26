using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.EntityFrameworkCore;

public class VitalLinkHttpApiHostMigrationsDbContext : AbpDbContext<VitalLinkHttpApiHostMigrationsDbContext>
{
    public VitalLinkHttpApiHostMigrationsDbContext(DbContextOptions<VitalLinkHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureVitalLink();
    }
}
