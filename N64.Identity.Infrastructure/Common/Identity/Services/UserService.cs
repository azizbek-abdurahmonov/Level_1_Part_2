using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Domain.Entity;
using N64.Identity.Persistence.DataAccess;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        await _dbContext.Users.AddAsync(user);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(id);

        _dbContext.Users.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        => DeleteAsync(user.Id, saveChanges, cancellationToken);

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _dbContext.Users.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<User> GetByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await _dbContext.Users.FindAsync(id)
            ?? throw new InvalidOperationException("User not found!");



    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(user.Id);

        found.FirstName = user.FirstName;
        found.LastName = user.LastName;
        found.EmailAddress = user.EmailAddress;
        found.Age = user.Age;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentNullException("Invalid name informations");

        if (!Regex.IsMatch(user.EmailAddress, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
            throw new ArgumentException("Invalid email address!");


        if (_dbContext.Users.Any(u => u.EmailAddress == user.EmailAddress))
            throw new InvalidOperationException("a user already exists with this email!");
    }
}
