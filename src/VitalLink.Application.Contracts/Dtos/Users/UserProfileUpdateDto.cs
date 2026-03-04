using System;

namespace VitalLink.Dtos.Users;

public class UserProfileUpdateDto
{
    public Guid BloodTypeId { get; set; }
    public double Radius { get; set; }
    public string? GeoJson { get; set; }
}