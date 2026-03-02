using System;
using System.Collections.Generic;

namespace VitalLink.Entities.Lookups;

public class BloodType : LookupBaseEntity
{
    public BloodType(Guid id, string name, int code) : base(id, name, code)
    {
    }
    
    public virtual ICollection<BloodRequest> BloodRequests { get; set; }
}