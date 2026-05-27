using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitalLink.Constants;
using VitalLink.Entities.Bloods;
using VitalLink.Entities.Lookups;
using VitalLink.Entities.Messages;
using VitalLink.Entities.Notifications;
using VitalLink.Entities.Users;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace VitalLink.Extensions;

public static class VitalLinkTableNameProvider
{
    public static string GetTableName<T>(this EntityTypeBuilder<T> entityTypeBuilder) 
        where T : class
    {
        TableNames!.TryGetValue(typeof(T).Name, out var name);
        return name!;
    }

    private static readonly Dictionary<string, string>? TableNames = new()
    {
        {nameof(BloodRequest),"BloodRequests"},
        {nameof(BloodType),"BloodTypes"},
        {nameof(BloodRequestStatus),"BloodRequestStatuses"},
        {nameof(Notification),"Notifications"},
        {nameof(NotificationEventType),"NotificationEventTypes"},
        {nameof(NotificationTemplate),"NotificationTemplates"},
        {nameof(ChatMessage),"ChatMessages"},
        {nameof(UserProfile),"UserProfiles"},
        {nameof(MessageStatus),"MessageStatuses"},
        {nameof(BloodRequestDonors),"BloodRequestDonors"},
    };
    
    public static void SetAbpTablePrefix(this ModelBuilder builder)
    {
        //Identity
        AbpIdentityDbProperties.DbTablePrefix = string.Empty;
        AbpIdentityDbProperties.DbSchema = DatabaseConstants.IdentitySchema;
        //Tenant
        AbpTenantManagementDbProperties.DbTablePrefix = string.Empty;
        AbpTenantManagementDbProperties.DbSchema = DatabaseConstants.IdentitySchema;
        //Setting
        AbpSettingManagementDbProperties.DbTablePrefix = string.Empty;
        AbpSettingManagementDbProperties.DbSchema = DatabaseConstants.SettingSchema;
        //Permission
        AbpPermissionManagementDbProperties.DbTablePrefix = string.Empty;
        AbpPermissionManagementDbProperties.DbSchema = DatabaseConstants.IdentitySchema;
        //Open Iddict
        AbpOpenIddictDbProperties.DbTablePrefix = string.Empty;
        AbpOpenIddictDbProperties.DbSchema = DatabaseConstants.OpenIddictSchema;
        //Feature
        AbpFeatureManagementDbProperties.DbTablePrefix = string.Empty;
        AbpFeatureManagementDbProperties.DbSchema = DatabaseConstants.IdentitySchema;
    }
}
