using System.Collections.Generic;
using System.Linq;
using Riok.Mapperly.Abstractions;
using VitalLink.Dtos.Bloods;
using VitalLink.Entities.Bloods;
using VitalLink.Enums;
using VitalLink.Extensions;
using VitalLink.Models.Bloods;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Mappers.Bloods;

[Mapper]
public partial class BloodRequestMapper : ITransientDependency
{
    public partial BloodRequestModel MapToModel(BloodRequestDto dto);

    public List<BloodRequestListDto> MapToDto(List<BloodRequest> bloodRequests)
    {
        var response = bloodRequests.Select(x => new BloodRequestListDto
        {
            CreatorId = x.CreatorId,
            BloodTypeId = x.BloodTypeId,
            CreatorName = $"{x.IdentityUser.Name} {x.IdentityUser.Surname}",
            BloodTypeName = ((BloodTypes)x.BloodType.Code).GetDescription(),
            Description = x.Description,
            GeoJson = x.Geom.ToGeoJson()
        })
        .ToList();
        return response;
    }
}