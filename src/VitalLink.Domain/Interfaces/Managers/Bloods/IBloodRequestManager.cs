using System;
using VitalLink.Entities.Bloods;
using VitalLink.Models.Bloods;

namespace VitalLink.Interfaces.Managers.Bloods;

public interface IBloodRequestManager : IBaseDomainService<BloodRequest>
{
    BloodRequest Create(
        BloodRequestModel bloodRequestModel, 
        Guid currentUserId
    );

    BloodRequest Update(
        BloodRequest bloodRequest,
        BloodRequestModel bloodRequestModel
    );

    void Close(BloodRequest? bloodRequest);
}