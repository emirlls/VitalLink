using System;
using Microsoft.EntityFrameworkCore;
using VitalLink.Constants;
using VitalLink.Entities.Lookups;

namespace VitalLink.Extensions;

public static class LookupSeeders
{
    public static void LookupSeeder(this ModelBuilder builder)
    {
        #region BloodTypes
        builder.Entity<BloodType>().HasData(
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.APositive.Id),
                LookupSeederConstants.BloodTypesConstants.APositive.Name,
                LookupSeederConstants.BloodTypesConstants.APositive.Code),
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.BPositive.Id),
                LookupSeederConstants.BloodTypesConstants.BPositive.Name,
                LookupSeederConstants.BloodTypesConstants.BPositive.Code),
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.AbPositive.Id),
                LookupSeederConstants.BloodTypesConstants.AbPositive.Name,
                LookupSeederConstants.BloodTypesConstants.AbPositive.Code),
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.ZeroPositive.Id),
                LookupSeederConstants.BloodTypesConstants.ZeroPositive.Name,
                LookupSeederConstants.BloodTypesConstants.ZeroPositive.Code),
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.ANegative.Id),
                LookupSeederConstants.BloodTypesConstants.ANegative.Name,
                LookupSeederConstants.BloodTypesConstants.ANegative.Code),
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.BNegative.Id),
                LookupSeederConstants.BloodTypesConstants.BNegative.Name,
                LookupSeederConstants.BloodTypesConstants.BNegative.Code),
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.AbNegative.Id),
                LookupSeederConstants.BloodTypesConstants.AbNegative.Name,
                LookupSeederConstants.BloodTypesConstants.AbNegative.Code),
            new BloodType(
                Guid.Parse(LookupSeederConstants.BloodTypesConstants.ZeroNegative.Id),
                LookupSeederConstants.BloodTypesConstants.ZeroNegative.Name,
                LookupSeederConstants.BloodTypesConstants.ZeroNegative.Code)
        );
        #endregion

        #region BloodRequestStatuses

        builder.Entity<BloodRequestStatus>().HasData(
            new BloodRequestStatus(
                Guid.Parse(LookupSeederConstants.BloodRequestStatusConstants.New.Id),
                LookupSeederConstants.BloodRequestStatusConstants.New.Name,
                LookupSeederConstants.BloodRequestStatusConstants.New.Code),
            new BloodRequestStatus(
                Guid.Parse(LookupSeederConstants.BloodRequestStatusConstants.InProgress.Id),
                LookupSeederConstants.BloodRequestStatusConstants.InProgress.Name,
                LookupSeederConstants.BloodRequestStatusConstants.InProgress.Code),
            new BloodRequestStatus(
                Guid.Parse(LookupSeederConstants.BloodRequestStatusConstants.Completed.Id),
                LookupSeederConstants.BloodRequestStatusConstants.Completed.Name,
                LookupSeederConstants.BloodRequestStatusConstants.Completed.Code)
        );

        #endregion

        #region MessageStatuses

        builder.Entity<MessageStatus>().HasData(
            new MessageStatus(
                Guid.Parse(LookupSeederConstants.MessageStatusConstants.Sent.Id),
                LookupSeederConstants.MessageStatusConstants.Sent.Name,
                LookupSeederConstants.MessageStatusConstants.Sent.Code),
            new MessageStatus(
                Guid.Parse(LookupSeederConstants.MessageStatusConstants.Read.Id),
                LookupSeederConstants.MessageStatusConstants.Read.Name,
                LookupSeederConstants.MessageStatusConstants.Read.Code)
        );

        #endregion
    }
}