using System;

namespace VitalLink.Models.Hubs;

public class HubConnectionModel
{
    public Guid UserId { get; set; }
    public string ConnectionId { get; set; }
    public string CultureKey { get; set; }
}