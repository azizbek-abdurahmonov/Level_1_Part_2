using System.Linq.Expressions;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);
    
    ValueTask<User> CreateAsync(User user);

    ValueTask<User> GetByIdAsync(Guid id);

    ValueTask<User> UpdateAsync(User user);
}