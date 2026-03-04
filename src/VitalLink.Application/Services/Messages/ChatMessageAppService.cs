using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using VitalLink.Constants;
using VitalLink.Dtos.Messages;
using VitalLink.Hubs;
using VitalLink.Interfaces.Managers.Messages;
using VitalLink.Mappers.Messages;
using VitalLink.Repositories.Messages;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace VitalLink.Services.Messages;

public class ChatMessageAppService : ApplicationService, IChatMessageService
{
    private IChatMessageManager ChatMessageManager =>
        LazyServiceProvider.LazyGetRequiredService<IChatMessageManager>();

    private IChatMessageRepository ChatMessageRepository =>
        LazyServiceProvider.LazyGetRequiredService<IChatMessageRepository>();

    private ChatMessageMapper ChatMessageMapper =>
        LazyServiceProvider.LazyGetRequiredService<ChatMessageMapper>();

    private readonly IHubContext<ChatHub> _hubContext;

    public ChatMessageAppService(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageAsync(
        ChatMessageCreateDto chatMessageCreateDto,
        CancellationToken cancellationToken = default
    )
    {
        var chatMessageCreateModel = ChatMessageMapper
            .MapToModel(chatMessageCreateDto, CurrentUser.GetId());

        var chatMessage = ChatMessageManager.Create(chatMessageCreateModel);

        await ChatMessageRepository.BulkInsertAsync(chatMessage, cancellationToken: cancellationToken);

        var targetIds = chatMessageCreateModel.TargetIds
            .Select(x => x.ToString())
            .ToList();

        await _hubContext.Clients
            .Users(targetIds)
            .SendAsync(
                HubConstants.Methods.ReceiveMessage,
                chatMessageCreateModel.Content,
                cancellationToken
            );
    }

    public async Task MarkMessageAsReadAsync(
        List<Guid> messageIds,
        CancellationToken cancellationToken = default
    )
    {
        var messages = await ChatMessageManager.TryGetListByQueryableAsync(q =>
                q.Where(x => messageIds.Contains(x.Id)),
            throwIfNull: true,
            cancellationToken: cancellationToken
        );

        messages.ForEach(x => x.StatusId = Guid.Parse(LookupSeederConstants.MessageStatusConstants.Read.Id));

        await ChatMessageRepository.UpdateManyAsync(
            messages,
            cancellationToken: cancellationToken
        );
    }
}