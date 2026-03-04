using System;
using System.Collections.Generic;

namespace VitalLink.Models.Messages;

public class ChatMessageCreateModel
{
    public Guid SenderId { get; set; }
    public List<Guid> TargetIds { get; set; }
    public string Content { get; set; }
}