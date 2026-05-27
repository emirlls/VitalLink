using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitalLink.Constants;
using VitalLink.Entities.Notifications;
using VitalLink.Extensions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace VitalLink.Configurations.Notifications;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.ToTable(builder.GetTableName(),DatabaseConstants.SchemaName);
        builder.ConfigureByConvention();

        builder.HasOne(x => x.NotificationEventType)
            .WithMany(x => x.NotificationTemplates)
            .HasForeignKey(x => x.NotificationEventTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Subject)
            .IsRequired(false);
    }
}