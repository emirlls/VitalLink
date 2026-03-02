using VitalLink.Localization;
using Volo.Abp.Application.Services;

namespace VitalLink;

public abstract class VitalLinkAppService : ApplicationService
{
    protected VitalLinkAppService()
    {
        LocalizationResource = typeof(VitalLinkResource);
        ObjectMapperContext = typeof(VitalLinkApplicationModule);
    }
}
