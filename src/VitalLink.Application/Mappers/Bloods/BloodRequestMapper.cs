using Riok.Mapperly.Abstractions;
using VitalLink.Dtos.Bloods;
using VitalLink.Models.Bloods;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Mappers.Bloods;

[Mapper]
public partial class BloodRequestMapper : ITransientDependency
{
    public partial BloodRequestModel MapToModel(BloodRequestDto dto);
}