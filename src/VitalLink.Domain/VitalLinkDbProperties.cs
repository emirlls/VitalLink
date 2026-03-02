namespace VitalLink;

public static class VitalLinkDbProperties
{
    public static string DbTablePrefix { get; set; } = "VitalLink";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "VitalLink";
}
