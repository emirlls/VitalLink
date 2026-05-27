using VitalLink.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace VitalLink.Permissions;

public class VitalLinkPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
    }

    protected static LocalizableString L(string name)
    {
        return LocalizableString.Create<VitalLinkResource>(name);
    }
}
