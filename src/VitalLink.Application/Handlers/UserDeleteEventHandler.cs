using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VitalLink.Constants;
using VitalLink.Enums;
using VitalLink.Etos;
using VitalLink.Extensions;
using VitalLink.Interfaces.Managers.Notifications;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace VitalLink.Handlers;

public class UserDeleteEventHandler : IDistributedEventHandler<UserDeleteEto>, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public UserDeleteEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleEventAsync(UserDeleteEto eventData)
    {
        var notificationEventTypeManager = _serviceProvider
            .GetRequiredService<INotificationEventTypeManager>();
        
        var notificationEventType =
            await notificationEventTypeManager.TryGetByAsync(x => 
                    x.Code == (int)NotificationEventTypes.UserDelete,
                throwIfNull:true);
        
        var notificationTemplateManager = _serviceProvider
            .GetRequiredService<INotificationTemplateManager>();
        
        var notificationTemplate =
            await notificationTemplateManager.TryGetByAsync(
                x => 
                    x.NotificationEventTypeId.Equals(notificationEventType.Id) &&
                    string.Equals(x.Culture,CultureInfo.CurrentCulture.Name),
                throwIfNull: true);
        
        var replacedTemplate = notificationTemplate.Content
            .Replace(NotificationTemplateProperties.UserDeleteTemplateParameters.Name, eventData.Name)
            .Replace(NotificationTemplateProperties.UserDeleteTemplateParameters.Surname, eventData.Surname)
            .Replace(NotificationTemplateProperties.UserDeleteTemplateParameters.ApplicationName, AppConstants.AppName);
        
        await _serviceProvider
            .SendMailAsync(eventData.Email,
                notificationTemplate.Subject ?? AppConstants.AppName,
                replacedTemplate
            );
    }
}