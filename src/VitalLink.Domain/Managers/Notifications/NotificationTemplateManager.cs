using Microsoft.Extensions.Localization;
using VitalLink.Constants;
using VitalLink.Entities.Notifications;
using VitalLink.Interfaces.Managers.Notifications;
using VitalLink.Localization;
using VitalLink.Repositories.Notifications;

namespace VitalLink.Managers.Notifications;

public class NotificationTemplateManager : BaseDomainService<NotificationTemplate>, INotificationTemplateManager
{
    public NotificationTemplateManager(
        INotificationTemplateRepository baseRepository,
        IStringLocalizer<VitalLinkResource> stringLocalizer
        ) : 
        base(
            baseRepository,
            stringLocalizer,
            ExceptionCodes.NotificationTemplate.NotFound,
            ExceptionCodes.NotificationTemplate.AlreadyExists
        )
    {
    }
}