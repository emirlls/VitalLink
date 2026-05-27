using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitalLink.Dtos.Messages;
using VitalLink.Permissions;
using VitalLink.Services.Messages;

namespace VitalLink.Controllers;

[Authorize]
[ApiController]
[Route("messages")]
public class MessageController : VitalLinkController
{
    private IChatMessageService ChatMessageService =>
        LazyServiceProvider.LazyGetRequiredService<IChatMessageService>();

    /// <summary>
    /// Use to send message.
    /// </summary>
    /// <param name="chatMessageCreateDto"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [Authorize(MessagePermissions.Default)]
    public async Task SendMessageAsync(
        ChatMessageCreateDto chatMessageCreateDto,
        CancellationToken cancellationToken = default
    ) => await ChatMessageService.SendMessageAsync(chatMessageCreateDto, cancellationToken);
    
    /// <summary>
    /// Use to mark messages as read.
    /// </summary>
    /// <param name="messageIds"></param>
    /// <param name="cancellationToken"></param>
    [HttpPatch]
    [Authorize(MessagePermissions.Update)]
    public async Task MarkMessageAsReadAsync(
        List<Guid> messageIds,
        CancellationToken cancellationToken = default
    ) => await ChatMessageService.MarkMessageAsReadAsync(
        messageIds,
        cancellationToken
    );
    
}