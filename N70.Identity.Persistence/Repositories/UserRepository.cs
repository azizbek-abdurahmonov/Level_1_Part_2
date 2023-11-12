using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.DataContexts;
using N70.Identity.Persistence.Repositories.Interfaces;

namespace N70.Identity.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User>, IUserRepository
{
    public UserRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        return base.Get(predicate);
    }

    public ValueTask<User> CreateAsync(User user)
    {
        return base.CreateAsync(user);
    }

    public ValueTask<User?> GetByIdAsync(Guid id)
    {
        return base.GetByIdAsync(id);
    }

    public ValueTask<User> UpdateAsync(User user)
    {
        return base.UpdateAsync(user);
    }
}