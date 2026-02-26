using Volo.Abp.Modularity;

namespace VitalLink;

[DependsOn(
    typeof(VitalLinkDomainModule),
    typeof(VitalLinkTestBaseModule)
)]
public class VitalLinkDomainTestModule : AbpModule
{

}
