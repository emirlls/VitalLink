using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using VitalLink.Models.Hubs;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Users;

namespace VitalLink.Hubs;

[Authorize]
public class BloodRequestHub : AbpHub
{
    private static readonly ConcurrentDictionary<string, HubConnectionModel> Connections = new();
    
    public override Task OnConnectedAsync()
    {
        var userId = CurrentUser.GetId();
        var connectionId = Context.ConnectionId;
        Connections.TryAdd(connectionId, new HubConnectionModel
        {
            UserId = userId,
            ConnectionId = Context.ConnectionId,
            CultureKey = Context.GetHttpContext()!.Request.Query["cultureKey"].ToString()
        });
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Connections.TryRemove(Context.ConnectionId, out _);
        return base.OnDisconnectedAsync(exception);
    }
}