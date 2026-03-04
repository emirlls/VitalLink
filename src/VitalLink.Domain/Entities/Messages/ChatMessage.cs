using System;
using VitalLink.Entities.Lookups;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace VitalLink.Entities.Messages;

public class ChatMessage : AuditedEntity<Guid>
{
    public Guid SenderId { get; set; }
    public Guid TargetId { get; set; }
    public Guid StatusId { get; set; }
    public string Content { get; set; }
    
    public  virtual MessageStatus MessageStatus { get; set; }
    public  virtual IdentityUser SenderUser { get; set; }

    public ChatMessage(
        Guid id,
        Guid senderId,
        Guid targetId, 
        string content,
        DateTime creationTime
    )
    {
        Id= id;
        SenderId = senderId;
        TargetId = targetId;
        Content = content;
        CreationTime = creationTime;
    }
}