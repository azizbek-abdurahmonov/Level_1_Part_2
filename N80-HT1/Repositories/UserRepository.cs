using N80_HT1.Caching.Interfaces;
using N80_HT1.Common.Models;
using N80_HT1.Common.Query;
using N80_HT1.DbContexts;
using N80_HT1.Entities;
using N80_HT1.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N80_HT1.Repositories;

public class UserRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<User, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()),
    IUserRepository
{
    public new ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public new ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate, bool asNoTracking)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, bool asNoTracking, CancellationToken cancellationToken)
    {
        return base.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }
}
