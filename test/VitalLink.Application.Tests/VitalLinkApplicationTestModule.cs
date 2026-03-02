using Volo.Abp.Modularity;

namespace VitalLink;

[DependsOn(
    typeof(VitalLinkApplicationModule),
    typeof(VitalLinkDomainTestModule)
    )]
public class VitalLinkApplicationTestModule : AbpModule
{

}
