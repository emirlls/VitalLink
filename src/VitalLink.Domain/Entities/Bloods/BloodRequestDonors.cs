using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace VitalLink.Entities.Bloods;

public class BloodRequestDonors : AuditedEntity<Guid>
{
    public Guid BloodRequestId { get; set; }
    public Guid UserId { get; set; }
    public bool IsAccepted { get; set; }
    
    public virtual BloodRequest BloodRequest { get; set; }
    public virtual IdentityUser IdentityUser { get; set; }

    public BloodRequestDonors(
        Guid id,
        Guid bloodRequestId,
        Guid userId,
        DateTime creationTime
    )
    {
        Id = id;
        BloodRequestId = bloodRequestId;
        UserId = userId;
        CreationTime = creationTime;
    }
}