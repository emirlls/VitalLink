using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using VitalLink.Extensions;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using VitalLink.Localization;
using Volo.Abp.Domain;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace VitalLink;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpDddDomainSharedModule)
)]
public class VitalLinkDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<VitalLinkDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<VitalLinkResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/VitalLink");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("VitalLink", typeof(VitalLinkResource));
        });
        
        LocalizationExtensions
            .SetLocalizer(context.Services.BuildServiceProviderFromFactory()
                .GetRequiredService<IStringLocalizer<VitalLinkResource>>());
    }
}
