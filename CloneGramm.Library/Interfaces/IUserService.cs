using CloneGramm.Library.Models;
using System.Linq.Expressions;

namespace CloneGramm.Library.Interfaces;

public interface IUserService
{
    IQueryable<User> GetAsync(Expression<Func<User, bool>> predicate);

    ValueTask<User> GetByIdAsync(Guid userId);

    ValueTask<User> CreateAsync(User user);

    ValueTask DeleteAsync(User user);

    ValueTask DeleteById(Guid id);

    ValueTask<User> UpdateAsync(User user);
}
