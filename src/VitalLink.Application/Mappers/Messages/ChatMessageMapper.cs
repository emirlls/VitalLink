using System;
using Riok.Mapperly.Abstractions;
using VitalLink.Dtos.Messages;
using VitalLink.Models.Messages;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Mappers.Messages;

[Mapper]
public partial class ChatMessageMapper : ITransientDependency
{
    public ChatMessageCreateModel MapToModel(ChatMessageCreateDto dto, Guid senderId)
    {
        return new ChatMessageCreateModel
        {
            SenderId = senderId,
            TargetIds = dto.TargetIds,
            Content = dto.Content
        };
    }
}