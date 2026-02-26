using Localization.Resources.AbpUi;
using VitalLink.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace VitalLink;

[DependsOn(
    typeof(VitalLinkApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class VitalLinkHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(VitalLinkHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<VitalLinkResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
