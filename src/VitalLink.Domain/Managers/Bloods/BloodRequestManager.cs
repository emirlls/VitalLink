using System;
using Microsoft.Extensions.Localization;
using VitalLink.Constants;
using VitalLink.Entities.Bloods;
using VitalLink.Extensions;
using VitalLink.Interfaces.Managers.Bloods;
using VitalLink.Localization;
using VitalLink.Models.Bloods;
using VitalLink.Repositories.Blood;
using Volo.Abp.MultiTenancy;

namespace VitalLink.Managers.Bloods;

public class BloodRequestManager : BaseDomainService<BloodRequest>, IBloodRequestManager
{
    public BloodRequestManager(IBloodRequestRepository baseRepository,
        IStringLocalizer<VitalLinkResource> stringLocalizer)
        : base(
            baseRepository, 
            stringLocalizer,
            ExceptionCodes.BloodRequests.NotFound, 
            ExceptionCodes.BloodRequests.AlreadyExists
        )
    {
    }

    public BloodRequest Create(
        BloodRequestModel bloodRequestModel, 
        Guid currentUserId
    )
    {
        var geom = bloodRequestModel.GeoJson.ToGeomFromGeoJson();
        var entity = new BloodRequest(
            GuidGenerator.Create(),
            CurrentTenant.GetId(),
            currentUserId,
            bloodRequestModel.BloodTypeId,
            bloodRequestModel.Description,
            geom,DateTime.Now
        )
        {
            StatusId = Guid.Parse(LookupSeederConstants.BloodRequestStatusConstants.New.Id)
        };
        return entity;
    }

    public BloodRequest Update(
        BloodRequest bloodRequest,
        BloodRequestModel bloodRequestModel
    )
    {
        var geom = bloodRequestModel.GeoJson.ToGeomFromGeoJson();
        bloodRequest.BloodTypeId = bloodRequestModel.BloodTypeId;
        bloodRequest.Description = bloodRequestModel.Description;
        bloodRequest.Geom = geom;
        return bloodRequest;
    }
}