using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Interfaces;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<User> CreateAsync(User user);
}
