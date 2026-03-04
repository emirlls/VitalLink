using Riok.Mapperly.Abstractions;
using VitalLink.Dtos.Users;
using VitalLink.Entities.Users;
using VitalLink.Enums;
using VitalLink.Extensions;
using VitalLink.Models.Users;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Mappers.Users;

[Mapper]
public partial class UserProfileMapper : ITransientDependency
{
    public UserProfileDto MapToDto(UserProfile entity)
    {
        var bloodTypeName = ((BloodTypes)entity.BloodType.Code).GetDescription();
        return new UserProfileDto
        {
            UserId = entity.UserId,
            BloodTypeId = entity.BloodTypeId,
            BloodTypeName = bloodTypeName,
            Radius = entity.Radius,
            GeoJson = entity.Geom.ToGeoJson()
        };
    }

    public UserProfileUpdateModel MapToModel(UserProfileCreateDto userProfileCreateDto)
    {
        return new UserProfileUpdateModel
        {
            BloodTypeId = userProfileCreateDto.BloodTypeId,
            Radius = userProfileCreateDto.Radius,
            Geom = userProfileCreateDto.GeoJson.ToGeomFromGeoJson()
        };
    }
}