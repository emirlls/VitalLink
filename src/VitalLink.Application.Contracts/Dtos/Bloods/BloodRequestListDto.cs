using System;

namespace VitalLink.Dtos.Bloods;

public class BloodRequestListDto
{
    public Guid? CreatorId { get; set; }
    public Guid BloodTypeId { get; set; }
    public string Number { get; set; }
    public string CreatorName { get; set; }
    public string BloodTypeName { get; set; }
    public string? Description { get; set; }
    public string GeoJson { get; set; }
}