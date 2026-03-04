using System;

namespace VitalLink.Models.Bloods;

public class BloodRequestDonorRequestModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string BloodRequestNumber { get; set; }
    public DateTime RequestDate { get; set; }
}