using System.Linq.Expressions;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);
    
    ValueTask<User> CreateAsync(User user);

    ValueTask<User> GetByIdAsync(Guid id);

    ValueTask<User> UpdateAsync(User user);
}