using VitalLink.Entities.Notifications;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Notifications;

public class EfNotificationEventTypeRepository : EfBaseRepository<NotificationEventType>,
    INotificationEventTypeRepository
{
    public EfNotificationEventTypeRepository(
        IDbContextProvider<VitalLinkDbContext> dbContextProvider) : 
        base(dbContextProvider)
    {
    }
}