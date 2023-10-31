using N66_HT1.Domain.Entities;
using System.Linq.Expressions;

namespace N66_HT1.Application.Common.DbManager.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}
