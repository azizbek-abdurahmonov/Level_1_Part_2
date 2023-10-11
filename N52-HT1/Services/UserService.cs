using System.Linq.Expressions;
using System.Text.RegularExpressions;
using N52_HT1.DataAccess;
using N52_HT1.Events;
using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Services;

public class UserService : IUserService
{
    private IDataContext _context;
    private AccountEventStore _eventStore;

    public UserService(IDataContext context, AccountEventStore eventStore)
    {
        _context = context;
        _eventStore = eventStore;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _context.Users.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<User> CreateAsync(User user)
    {
        Validate(user);

        var entity = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        await _eventStore.CreateUserAddedEventAsync(user);

        return entity.Entity;
    }

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName)
            || string.IsNullOrWhiteSpace(user.LastName))
        {
            throw new ArgumentException("Invalid full name");
        }

        if (!Regex.IsMatch(user.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
            throw new ArgumentException("Invalid email");
    }
}