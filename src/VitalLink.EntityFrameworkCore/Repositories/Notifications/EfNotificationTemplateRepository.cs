using VitalLink.Entities.Notifications;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Notifications;

public class EfNotificationTemplateRepository : EfBaseRepository<NotificationTemplate>,
    INotificationTemplateRepository
{
    public EfNotificationTemplateRepository(
        IDbContextProvider<VitalLinkDbContext> dbContextProvider) : 
        base(dbContextProvider)
    {
    }
}