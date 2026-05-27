using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VitalLink.Dtos.Messages;
using Volo.Abp.Application.Services;

namespace VitalLink.Services.Messages;

public interface IChatMessageService : IApplicationService
{
    Task SendMessageAsync(
        ChatMessageCreateDto chatMessageCreateDto,
        CancellationToken cancellationToken = default
    );

    Task MarkMessageAsReadAsync(
        List<Guid> messageIds,
        CancellationToken cancellationToken
    );
}