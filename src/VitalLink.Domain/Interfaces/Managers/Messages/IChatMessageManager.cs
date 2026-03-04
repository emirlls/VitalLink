using System.Collections.Generic;
using VitalLink.Entities.Messages;
using VitalLink.Models.Messages;

namespace VitalLink.Interfaces.Managers.Messages;

public interface IChatMessageManager : IBaseDomainService<ChatMessage>
{
    List<ChatMessage> Create(ChatMessageCreateModel chatMessageCreateModel);
}