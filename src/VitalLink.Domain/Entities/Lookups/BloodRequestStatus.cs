using System;
using System.Collections.Generic;
using VitalLink.Entities.Bloods;

namespace VitalLink.Entities.Lookups;

public class BloodRequestStatus : LookupBaseEntity
{
    public BloodRequestStatus(Guid id, string name, int code) : base(id, name, code)
    {
    }
    public virtual ICollection<BloodRequest> BloodRequests { get; set; }
}