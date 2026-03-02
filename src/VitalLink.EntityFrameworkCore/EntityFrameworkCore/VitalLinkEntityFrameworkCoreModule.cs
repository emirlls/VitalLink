using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace VitalLink.EntityFrameworkCore;

[DependsOn(
    typeof(VitalLinkDomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule)
)]
public class VitalLinkEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<VitalLinkDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<VitalLinkDbContext>(opts =>
            {
                opts.DbContextOptions.UseNpgsql(npgsqlOptions =>
                {
                    npgsqlOptions.UseNetTopologySuite();
                });
            });
        });
        context.Services.AddTransient(typeof(IBaseRepository<>), typeof(EfBaseRepository<>));
    }
}
