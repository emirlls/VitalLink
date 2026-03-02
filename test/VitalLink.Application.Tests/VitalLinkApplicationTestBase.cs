using Volo.Abp.Modularity;

namespace VitalLink;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class VitalLinkApplicationTestBase<TStartupModule> : VitalLinkTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
