using System;

namespace VitalLink.Dtos.Users;

public class UserProfileDto
{
    public Guid UserId { get; set; }
    public Guid BloodTypeId { get; set; }
    public double Radius { get; set; }
    public string BloodTypeName { get; set; }
    public string? GeoJson { get; set; }
}