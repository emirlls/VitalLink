using System.ComponentModel;

namespace VitalLink.Enums;

public enum BloodTypes
{
    [Description("BloodTypes:00")]
    APositive = 0,
    [Description("BloodTypes:01")]
    BPositive = 1,
    [Description("BloodTypes:02")]
    AbPositive = 2,
    [Description("BloodTypes:03")]
    ZeroPositive = 3,
    [Description("BloodTypes:04")]
    ANegative = 4,
    [Description("BloodTypes:05")]
    BNegative = 5,
    [Description("BloodTypes:06")]
    AbNegative = 6,
    [Description("BloodTypes:07")]
    ZeroNegative = 7,
}