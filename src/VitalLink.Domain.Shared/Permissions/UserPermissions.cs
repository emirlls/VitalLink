namespace VitalLink.Permissions;

public static class UserPermissions
{
    public const string GroupName = "User";
    public const string Default = $"{GroupName}.{PermissionTypes.Default}";
    public const string Create = $"{GroupName}.{PermissionTypes.Create}";
    public const string Update = $"{GroupName}.{PermissionTypes.Update}";
    public const string Delete = $"{GroupName}.{PermissionTypes.Delete}";
    public const string Export = $"{GroupName}.{PermissionTypes.Export}";
}