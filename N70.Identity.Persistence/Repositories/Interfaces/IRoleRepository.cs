using System.Linq.Expressions;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Persistence.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>> predicate);
}