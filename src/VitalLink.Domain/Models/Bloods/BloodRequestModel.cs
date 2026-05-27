using System;

namespace VitalLink.Models.Bloods;

public class BloodRequestModel
{
    public Guid BloodTypeId { get; set; }
    public string? Description { get; set; }
    public string GeoJson { get; set; }
}