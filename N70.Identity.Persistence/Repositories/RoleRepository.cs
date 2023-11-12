using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.DataContexts;
using N70.Identity.Persistence.Repositories.Interfaces;

namespace N70.Identity.Persistence.Repositories;

public class RoleRepository : EntityRepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>> predicate)
    {
        return base.Get(predicate);
    }
}