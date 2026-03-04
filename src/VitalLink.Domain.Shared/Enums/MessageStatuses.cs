using System.ComponentModel;

namespace VitalLink.Enums;

public enum MessageStatuses
{
    [Description("MessageStatuses:00")]
    Sent = 0,
    [Description("MessageStatuses:01")]
    Read = 1
}