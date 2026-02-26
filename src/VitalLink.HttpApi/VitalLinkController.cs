using VitalLink.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VitalLink;

public abstract class VitalLinkController : AbpControllerBase
{
    protected VitalLinkController()
    {
        LocalizationResource = typeof(VitalLinkResource);
    }
}
