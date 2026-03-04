using System;
using VitalLink.Constants;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace VitalLink.Etos;
[EventName(EventConstants.EventBus.BloodRequestCreate)]
public class BloodRequestCreateEto : EtoBase
{
    public Guid BloodRequestId { get; set; }
}