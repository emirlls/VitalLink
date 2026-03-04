using System;

namespace VitalLink.Models.Bloods;

public class BloodRequestCreatedEventModel
{
    public Guid Id { get; set; }
    public Guid? CreatorId { get; set; }
    public Guid BloodTypeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? GeoJson { get; set; }
    public DateTime CreationTime { get; set; }
}