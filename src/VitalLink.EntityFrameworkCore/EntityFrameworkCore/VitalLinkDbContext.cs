using Microsoft.EntityFrameworkCore;
using VitalLink.Entities;
using VitalLink.Entities.Lookups;
using VitalLink.Extensions;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace VitalLink.EntityFrameworkCore;

[ConnectionStringName(VitalLinkDbProperties.ConnectionStringName)]
public class VitalLinkDbContext : AbpDbContext<VitalLinkDbContext>, IVitalLinkDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<BloodRequest>  BloodRequests { get; set; }
    public DbSet<BloodRequestStatus>  BloodRequestStatuses { get; set; }
    public DbSet<BloodType>  BloodTypes { get; set; }
    public VitalLinkDbContext(DbContextOptions<VitalLinkDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.LookupSeeder();
        builder.SetAbpTablePrefix();

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureFeatureManagement();
        builder.ConfigureVitalLink();
        builder.ApplyConfigurationsFromAssembly(typeof(VitalLinkDbContext).Assembly);
        builder.ToSnakeCase();
    }
}
