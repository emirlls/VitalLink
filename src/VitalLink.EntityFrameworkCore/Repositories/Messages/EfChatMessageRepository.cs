using VitalLink.Entities.Messages;
using VitalLink.EntityFrameworkCore;
using VitalLink.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VitalLink.Repositories.Messages;

public class EfChatMessageRepository : EfBaseRepository<ChatMessage>, IChatMessageRepository
{
    public EfChatMessageRepository(
        IDbContextProvider<VitalLinkDbContext> dbContextProvider
        ) : base(dbContextProvider)
    {
    }
}