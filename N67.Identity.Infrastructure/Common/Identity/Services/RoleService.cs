using Identity.Domain.Entities;
using N67.Identity.Application.Common.Identity.Services;
using N67.Identity.Persistence.DataAccess;
using System.Linq.Expressions;

namespace N67.Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly AppDbContext _dbContext;

    public RoleService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.Roles.AddAsync(role);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return role;
    }

    public ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
        => DeleteAsync(role.Id, saveChanges, cancellationToken);

    public async ValueTask<Role> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(id)
            ?? throw new InvalidOperationException("ROle not found!");

        _dbContext.Roles.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = null)
        => predicate != null ? _dbContext.Roles.Where(predicate) : _dbContext.Roles;

    public async ValueTask<Role?> GetByIdAsync(Guid id)
        => await _dbContext.Roles.FindAsync(id);

    public async ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await _dbContext.Roles.FindAsync(role.Id)
            ?? throw new InvalidOperationException("Role not found!");

        found.Name = role.Name;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }
}
