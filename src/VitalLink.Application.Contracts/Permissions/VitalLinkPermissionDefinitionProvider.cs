using VitalLink.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace VitalLink.Permissions;

public class VitalLinkPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VitalLinkPermissions.GroupName, L("Permission:VitalLink"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VitalLinkResource>(name);
    }
}
