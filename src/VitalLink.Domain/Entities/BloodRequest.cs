using System;
using NetTopologySuite.Geometries;
using VitalLink.Entities.Lookups;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace VitalLink.Entities;

public class BloodRequest : FullAuditedAggregateRoot<Guid>
{
    public Guid RequesterUserId { get; set; }
    public Guid BloodTypeId { get; set; }
    public Guid StatusId { get; set; }
    public bool IsClosed { get; set; }
    public string? Description { get; set; }
    public Geometry Geom { get; set; }
    
    public virtual IdentityUser IdentityUser { get; set; }
    public virtual BloodType BloodType { get; set; }
    public virtual BloodRequestStatus BloodRequestStatus { get; set; }
}