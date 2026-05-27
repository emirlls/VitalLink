using Microsoft.Extensions.Localization;
using VitalLink.Constants;
using VitalLink.Entities.Notifications;
using VitalLink.Interfaces.Managers.Notifications;
using VitalLink.Localization;
using VitalLink.Repositories.Notifications;

namespace VitalLink.Managers.Notifications;

public class NotificationEventTypeManager : BaseDomainService<NotificationEventType>, INotificationEventTypeManager
{
    public NotificationEventTypeManager(
        INotificationEventTypeRepository baseRepository,
        IStringLocalizer<VitalLinkResource> stringLocalizer
    ) : base(baseRepository,
        stringLocalizer, 
        ExceptionCodes.NotificationEventType.NotFound,
        ExceptionCodes.NotificationEventType.AlreadyExists
    )
    {
    }
}