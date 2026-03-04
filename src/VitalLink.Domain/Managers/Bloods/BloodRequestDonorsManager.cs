using System;
using Microsoft.Extensions.Localization;
using VitalLink.Constants;
using VitalLink.Entities.Bloods;
using VitalLink.Interfaces.Managers.Bloods;
using VitalLink.Localization;
using VitalLink.Repositories.Base;

namespace VitalLink.Managers.Bloods;

public class BloodRequestDonorsManager : BaseDomainService<BloodRequestDonors>, IBloodRequestDonorsManager
{
    public BloodRequestDonorsManager(IBaseRepository<BloodRequestDonors> baseRepository,
        IStringLocalizer<VitalLinkResource> stringLocalizer)
        : base(
            baseRepository,
            stringLocalizer,
            ExceptionCodes.BloodRequestDonors.NotFound,
            ExceptionCodes.BloodRequestDonors.AlreadyExists
        )
    {
    }

    public BloodRequestDonors Create(Guid bloodRequestId, Guid currentUserId)
    {
        var entity = new BloodRequestDonors(
            GuidGenerator.Create(),
            bloodRequestId,
            currentUserId, 
            DateTime.Now
        );
        return entity;
    }

    public void Accept(BloodRequestDonors? bloodRequestDonor)
    {
        bloodRequestDonor.IsAccepted =  true;
    }
}