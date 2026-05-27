using System;
using System.Collections.Generic;
using VitalLink.Entities.Lookups;

namespace VitalLink.Entities.Notifications;

public class NotificationEventType : LookupBaseEntity
{
    public NotificationEventType(Guid id, string name, int code) : base(id, name, code)
    {
    }
    public virtual ICollection<Notification> Notifications { get; set; }
    public virtual ICollection<NotificationTemplate> NotificationTemplates { get; set; }
}