using System;

namespace VitalLink.Dtos.Bloods;

public class BloodRequestDto
{
    public Guid BloodTypeId { get; set; }
    public string? Description { get; set; }
    public string GeoJson { get; set; }
}