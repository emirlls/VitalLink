using System.ComponentModel;

namespace VitalLink.Enums;

public enum BloodRequestStatuses
{
    [Description("BloodRequestStatuses:00")]
    New = 0,
    [Description("BloodRequestStatuses:01")]
    InProgress = 1,
    [Description("BloodRequestStatuses:02")]
    Completed = 2
}