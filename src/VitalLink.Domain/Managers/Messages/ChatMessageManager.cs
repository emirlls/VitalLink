using System;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using VitalLink.Constants;
using VitalLink.Entities.Messages;
using VitalLink.Interfaces.Managers.Messages;
using VitalLink.Localization;
using VitalLink.Models.Messages;
using VitalLink.Repositories.Messages;

namespace VitalLink.Managers.Messages;

public class ChatMessageManager : BaseDomainService<ChatMessage>, IChatMessageManager
{
    public ChatMessageManager(
        IChatMessageRepository baseRepository,
        IStringLocalizer<VitalLinkResource> stringLocalizer
        ) : base(
        baseRepository, 
        stringLocalizer,
        ExceptionCodes.ChatMessage.NotFound,
        ExceptionCodes.ChatMessage.AlreadyExists
    )
    {
    }

    public List<ChatMessage> Create(ChatMessageCreateModel chatMessageCreateModel)
    {
        var chatMessages = new List<ChatMessage>();
        foreach (var targetId in chatMessageCreateModel.TargetIds)
        {
            chatMessages.Add(new ChatMessage(GuidGenerator.Create(),
                chatMessageCreateModel.SenderId,
                targetId,
                chatMessageCreateModel.Content,
                DateTime.Now));
        }

        return chatMessages;
    }
}