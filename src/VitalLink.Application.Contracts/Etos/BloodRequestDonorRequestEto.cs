using System;
using VitalLink.Constants;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace VitalLink.Etos;

[EventName(EventConstants.EventBus.BloodRequestDonorRequest)]
public class BloodRequestDonorRequestEto : EtoBase
{
    public Guid Id { get; set; }
}