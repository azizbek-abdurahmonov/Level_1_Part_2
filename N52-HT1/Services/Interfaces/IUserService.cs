using System.Linq.Expressions;
using N52_HT1.Models;

namespace N52_HT1.Services.Interfaces;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);
    ValueTask<User> CreateAsync(User user);
}