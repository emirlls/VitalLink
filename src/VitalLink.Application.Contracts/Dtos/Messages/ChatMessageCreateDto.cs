using System;
using System.Collections.Generic;

namespace VitalLink.Dtos.Messages;

public class ChatMessageCreateDto
{
    public List<Guid> TargetIds { get; set; } // user or group id
    public string Content { get; set; }
}