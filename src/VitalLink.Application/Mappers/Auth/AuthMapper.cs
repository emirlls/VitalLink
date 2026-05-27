using Riok.Mapperly.Abstractions;
using VitalLink.Dtos.Auth;
using VitalLink.Models.Auth;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Mappers.Auth;

[Mapper]
public partial class AuthMapper : ITransientDependency
{
    public partial RegisterModel MapToDto(RegisterDto dto);
}