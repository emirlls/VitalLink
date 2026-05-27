using System;
using VitalLink.Attributes;
using VitalLink.Filtering.Base;

namespace VitalLink.Filtering.Bloods;

public class BloodRequestFilters : DynamicFilterRequest
{
    [FilterMapped("BloodTypeId")] 
    internal Guid? BloodTypeId { get; set; }
    
    [FilterMapped("StatusId")] 
    internal Guid? StatusId { get; set; }
    
    [FilterMapped("Description")] 
    internal string? Description { get; set; }
    
    [FilterMapped("Number")] 
    internal string? Number { get; set; }
}