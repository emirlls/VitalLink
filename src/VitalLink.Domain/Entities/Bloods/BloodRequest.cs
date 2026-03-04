using System;
using NetTopologySuite.Geometries;
using VitalLink.Entities.Lookups;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace VitalLink.Entities.Bloods;

public class BloodRequest : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public Guid RequesterUserId { get; set; }
    public Guid BloodTypeId { get; set; }
    public Guid StatusId { get; set; }
    public bool IsClosed { get; set; }
    public string? Description { get; set; }
    public Geometry Geom { get; set; }

    public virtual IdentityUser IdentityUser { get; set; }
    public virtual BloodType BloodType { get; set; }
    public virtual BloodRequestStatus BloodRequestStatus { get; set; }

    public BloodRequest(
        Guid id,
        Guid tenantId,
        Guid requesterUserId,
        Guid bloodTypeId,
        string? description,
        Geometry geom,
        DateTime creationTime
    )
    {
        Id= id;
        TenantId = tenantId;
        RequesterUserId = requesterUserId;
        BloodTypeId = bloodTypeId;
        Description = description;
        Geom = geom;
        CreationTime =  creationTime;
    }
}