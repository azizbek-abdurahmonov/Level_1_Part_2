using N64.Identity.Domain.Entity;
using System.Linq.Expressions;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}
