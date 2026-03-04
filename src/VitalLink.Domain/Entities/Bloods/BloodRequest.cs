using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using VitalLink.Entities.Lookups;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace VitalLink.Entities.Bloods;

public class BloodRequest : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public Guid BloodTypeId { get; set; }
    public Guid StatusId { get; set; }
    public string Number { get; set; }
    public string? Description { get; set; }
    public Geometry Geom { get; set; }

    public virtual IdentityUser IdentityUser { get; set; }
    public virtual BloodType BloodType { get; set; }
    public virtual BloodRequestStatus BloodRequestStatus { get; set; }

    public virtual ICollection<BloodRequestDonors> BloodRequestDonors { get; set; }
    public BloodRequest(
        Guid id,
        Guid tenantId,
        Guid bloodTypeId,
        string? description,
        string number,
        Geometry geom,
        DateTime creationTime,
        Guid creatorId
    )
    {
        Id= id;
        TenantId = tenantId;
        BloodTypeId = bloodTypeId;
        Description = description;
        Number = number;
        Geom = geom;
        CreationTime =  creationTime;
        CreatorId = creatorId;
    }
}