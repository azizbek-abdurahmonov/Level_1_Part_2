using System.Linq.Expressions;
using System.Text.RegularExpressions;
using ToDoApp.DataAccess;
using ToDoApp.Models;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services;

public class UserService : IUserService
{
    private IDataContext _context;

    public UserService(IDataContext context)
    {
        _context = context;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _context.Users.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids)
        => new ValueTask<ICollection<User>>(_context.Users.Where(u => ids.Contains(u.Id)).ToArray());

    public async ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
        => await _context.Users.FindAsync(id);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        ToValidate(user);

        await _context.Users.AddAsync(user);

        if (saveChanges)
            await _context.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        ToValidate(user);

        var foundUser = await _context.Users.FindAsync(user.Id);

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.Email = user.Email;
        foundUser.Password = user.Password;

        await _context.Users.UpdateAsync(foundUser);

        if (saveChanges)
            await _context.SaveChangesAsync();

        return foundUser;
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(user.Id, saveChanges, cancellationToken);
    }

    public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var found = await _context.Users.FindAsync(id);

        if (found.IsDeleted)
            throw new InvalidOperationException("User already deleted");

        await _context.Users.RemoveAsync(found);

        if (saveChanges)
            await _context.SaveChangesAsync();

        return found;
    }

    public ValueTask<User> UploadImageAsync(Guid userId, UploadImageDto image, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private void ToValidate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new Exception("Invalid fullname!");

        if (!Regex.IsMatch(user.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            throw new Exception("Invalid email!");
    }
}