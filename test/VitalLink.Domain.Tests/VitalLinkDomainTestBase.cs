using Volo.Abp.Modularity;

namespace VitalLink;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class VitalLinkDomainTestBase<TStartupModule> : VitalLinkTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
