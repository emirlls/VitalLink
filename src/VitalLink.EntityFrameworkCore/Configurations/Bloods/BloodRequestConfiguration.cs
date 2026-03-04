using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitalLink.Constants;
using VitalLink.Entities.Bloods;
using VitalLink.Extensions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace VitalLink.Configurations.Bloods;

public class BloodRequestConfiguration : IEntityTypeConfiguration<BloodRequest>
{
    public void Configure(EntityTypeBuilder<BloodRequest> builder)
    {
        builder.ToTable(builder.GetTableName(),DatabaseConstants.SchemaName);
        builder.ConfigureByConvention();
        
        builder.HasOne(x => x.IdentityUser)
            .WithMany()
            .HasForeignKey(x => x.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x=>x.BloodType)
            .WithMany(x=>x.BloodRequests)
            .HasForeignKey(x=>x.BloodTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x=>x.BloodRequestStatus)
            .WithMany(x=>x.BloodRequests)
            .HasForeignKey(x=>x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}