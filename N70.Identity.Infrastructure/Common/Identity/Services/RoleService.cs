using System.Linq.Expressions;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;
using N70.Identity.Domain.Enums;
using N70.Identity.Persistence.Repositories.Interfaces;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public ValueTask<Role> GetByTypeAsync(RoleType roleType)
    {
        var role = _roleRepository.Get(role => role.Type == roleType).FirstOrDefault();

        return new(role);
    }
}