using System;

namespace VitalLink.Dtos.Users;

public class UserProfileCreateDto
{
    public Guid BloodTypeId { get; set; }
    public double Radius { get; set; }
    public string? GeoJson { get; set; }
}