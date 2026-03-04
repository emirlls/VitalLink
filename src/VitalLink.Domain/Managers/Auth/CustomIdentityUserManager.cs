using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using VitalLink.Constants;
using VitalLink.Interfaces.Managers.Auth;
using VitalLink.Localization;
using VitalLink.Models.Auth;
using VitalLink.Repositories.Base;
using Volo.Abp.Identity;

namespace VitalLink.Managers.Auth;

public class CustomIdentityUserManager : BaseDomainService<IdentityUser>, ICustomIdentityUserManager
{
    public CustomIdentityUserManager(
        IBaseRepository<IdentityUser> baseRepository,
        IStringLocalizer<VitalLinkResource> stringLocalizer
    ) :
        base(baseRepository,
            stringLocalizer,
            ExceptionCodes.IdentityUser.NotFound,
            ExceptionCodes.IdentityUser.AlreadyExists
        )
    {
    }

    public async Task<IdentityUser> Create(Guid id, Guid? tenantId, RegisterModel model)
    {
        var user = new IdentityUser(id, model.Username, model.Email, tenantId)
        {
            Name = model.FirstName,
            Surname = model.LastName
        };
        return user;
    }
    
}