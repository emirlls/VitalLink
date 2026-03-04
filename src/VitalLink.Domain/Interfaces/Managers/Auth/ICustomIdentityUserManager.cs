using System;
using System.Threading.Tasks;
using VitalLink.Models.Auth;
using Volo.Abp.Identity;

namespace VitalLink.Interfaces.Managers.Auth;

public interface ICustomIdentityUserManager : IBaseDomainService<IdentityUser>
{
    Task<IdentityUser> Create(Guid id, Guid? tenantId, RegisterModel model);
}