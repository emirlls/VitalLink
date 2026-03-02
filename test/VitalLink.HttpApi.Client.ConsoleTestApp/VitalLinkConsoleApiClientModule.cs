using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace VitalLink;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VitalLinkHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class VitalLinkConsoleApiClientModule : AbpModule
{

}
