using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace VitalLink;

[DependsOn(
    typeof(VitalLinkDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class VitalLinkApplicationContractsModule : AbpModule
{

}
