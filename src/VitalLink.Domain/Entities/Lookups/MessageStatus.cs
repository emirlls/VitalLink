using System;
using System.Collections.Generic;
using VitalLink.Entities.Messages;

namespace VitalLink.Entities.Lookups;

public class MessageStatus : LookupBaseEntity
{
    public MessageStatus(Guid id, string name, int code) : base(id, name, code)
    {
    }
    
    public virtual ICollection<ChatMessage>  ChatMessages { get; set; }
}