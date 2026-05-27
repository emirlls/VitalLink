using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitalLink.Constants;
using VitalLink.Entities.Bloods;
using VitalLink.Extensions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace VitalLink.Configurations.Bloods;

public class BloodRequestDonorsConfiguration : IEntityTypeConfiguration<BloodRequestDonors>
{
    public void Configure(EntityTypeBuilder<BloodRequestDonors> builder)
    {
        builder.ToTable(builder.GetTableName(), DatabaseConstants.SchemaName);
        builder.ConfigureByConvention();

        builder.Property(x => x.IsAccepted).HasDefaultValue(false);

        builder.HasOne(x => x.BloodRequest)
            .WithMany(x => x.BloodRequestDonors)
            .HasForeignKey(x => x.BloodRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.IdentityUser)
            .WithMany()
            .HasForeignKey(x => x.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}