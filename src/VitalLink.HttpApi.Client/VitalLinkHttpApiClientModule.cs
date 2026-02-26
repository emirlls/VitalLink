using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace VitalLink;

[DependsOn(
    typeof(VitalLinkApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class VitalLinkHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(VitalLinkApplicationContractsModule).Assembly,
            VitalLinkRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<VitalLinkHttpApiClientModule>();
        });

    }
}
