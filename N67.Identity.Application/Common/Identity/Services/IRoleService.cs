using N67.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N67.Identity.Application.Common.Identity.Services;

public interface IRoleService
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = null);

    ValueTask<Role?> GetByIdAsync(Guid id);

    ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
