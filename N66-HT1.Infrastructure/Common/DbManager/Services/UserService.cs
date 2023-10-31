using N66_HT1.Application.Common.DbManager.Services;
using N66_HT1.Domain.Entities;
using N66_HT1.Persistence.DataAccess;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N66_HT1.Infrastructure.Common.DbManager.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        await _dbContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = _dbContext.Users.FirstOrDefault(user => user.Id == id)
            ?? throw new ArgumentNullException("User not found!");

        _dbContext.Users.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public ValueTask DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(user.Id, saveChanges, cancellationToken);
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _dbContext.Users.Where(predicate.Compile()).AsQueryable();

    public ValueTask<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => new(_dbContext.Users.FirstOrDefault(user => user.Id == id)
        ?? throw new InvalidOperationException("User not found!"));

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        var found = await GetByIdAsync(user.Id);
        found.FirstName = user.FirstName;
        found.LastName = user.LastName;
        found.Email = user.Email;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentNullException("Invalid name informations");

        if (!Regex.IsMatch(user.Email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
            throw new ArgumentException("Invalid email address!");

        if (string.IsNullOrWhiteSpace(user.PasswordHash) || user.PasswordHash.Length < 8)
            throw new ArgumentException("Invalid password!");

        if (_dbContext.Users.Any(u => u.Email == user.Email))
            throw new InvalidOperationException("a user already exists with this email!");
    }
}
