using Volo.Abp.Reflection;

namespace VitalLink.Permissions;

public class VitalLinkPermissions
{
    public const string GroupName = "VitalLink";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(VitalLinkPermissions));
    }
}
