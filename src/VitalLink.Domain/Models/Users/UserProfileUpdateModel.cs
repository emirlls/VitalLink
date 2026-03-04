using System;
using NetTopologySuite.Geometries;

namespace VitalLink.Models.Users;

public class UserProfileUpdateModel
{
    public Guid BloodTypeId { get; set; }
    public double Radius { get; set; }
    public Geometry Geom { get; set; }
}