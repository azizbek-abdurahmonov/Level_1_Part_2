using N80_HT1.Common.Query;
using N80_HT1.Entities;
using System.Linq.Expressions;

namespace N80_HT1.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
