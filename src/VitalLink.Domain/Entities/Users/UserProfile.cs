using System;
using NetTopologySuite.Geometries;
using VitalLink.Entities.Lookups;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace VitalLink.Entities.Users;

public class UserProfile : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public Guid UserId { get; set; }
    public Guid BloodTypeId { get; set; }
    public double Radius { get; set; }
    public Geometry Geom { get; set; }
    
    public virtual IdentityUser IdentityUser { get; set; }
    public virtual BloodType BloodType { get; set; }

    public UserProfile(
        Guid id,
        Guid? tenantId, 
        Guid userId,
        Guid bloodTypeId,
        double radius,
        Geometry geom,
        DateTime creationTime
    )
    {
        Id = id;
        TenantId = tenantId;
        UserId = userId;
        BloodTypeId = bloodTypeId;
        Radius = radius;
        Geom = geom;
        CreationTime = creationTime;
    }
}