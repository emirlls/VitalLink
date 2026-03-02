using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitalLink.Constants;
using VitalLink.Entities.Lookups;
using VitalLink.Extensions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace VitalLink.Configurations.Lookups;

public class BloodRequestStatusConfiguration : IEntityTypeConfiguration<BloodRequestStatus>
{
    public void Configure(EntityTypeBuilder<BloodRequestStatus> builder)
    {
        builder.ToTable(builder.GetTableName(),DatabaseConstants.SchemaName);
        builder.ConfigureByConvention();
    }
}