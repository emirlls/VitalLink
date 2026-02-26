using Microsoft.EntityFrameworkCore;

namespace VitalLink.Extensions;

public static class LookupSeeders
{
    public static void LookupSeeder(this ModelBuilder builder)
    {
        // #region BloodTypes
        // builder.Entity<BloodType>().HasData(
        //     new BloodType(
        //         Guid.Parse(LookupSeederConstants.ChatTypesConstants.Directly.Id),
        //         LookupSeederConstants.ChatTypesConstants.Directly.Name,
        //         LookupSeederConstants.ChatTypesConstants.Directly.Code),
        //     
        //     new BloodType(Guid.Parse(LookupSeederConstants.ChatTypesConstants.Group.Id),
        //         LookupSeederConstants.ChatTypesConstants.Group.Name,
        //         LookupSeederConstants.ChatTypesConstants.Group.Code)
        // );
        // #endregion
    }
}