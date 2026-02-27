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
        
        //todo : Will add blood request status.
    }
}