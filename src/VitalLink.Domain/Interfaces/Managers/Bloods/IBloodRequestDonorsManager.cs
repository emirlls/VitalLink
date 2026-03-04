using System;
using VitalLink.Entities.Bloods;

namespace VitalLink.Interfaces.Managers.Bloods;

public interface IBloodRequestDonorsManager : IBaseDomainService<BloodRequestDonors>
{
    BloodRequestDonors Create(
        Guid bloodRequestId,
        Guid currentUserId
    );

    void Accept(BloodRequestDonors? bloodRequestDonor);
}