using System.Linq.Expressions;
using Identity.Domain.Entities;
using N67.Identity.Application.Common.Identity.Services;
using N67.Identity.Persistence.DataAccess;

namespace N67.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null)
        => predicate != null ? _dbContext.Users.Where(predicate) : _dbContext.Users;

    public async ValueTask<User?> GetByIdAsync(Guid id)
        => await _dbContext.Users.FindAsync(id);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        user.Id = Guid.Empty;
        await _dbContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(user.Id)
                    ?? throw new InvalidOperationException("User not found!");

        found.FirstName = user.FirstName;
        found.LastName = user.LastName;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => DeleteAsync(user.Id, saveChanges, cancellationToken);

    public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(id)
                    ?? throw new InvalidOperationException("User not found!");

        _dbContext.Users.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }
}