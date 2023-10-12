using N53_HT1.Api.DataAccess;
using N53_HT1.Api.Interfaces;
using N53_HT1.Api.Models;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N53_HT1.Api.Services;

public class UserService : IUserService
{
    private readonly IDataContext _context;

    public UserService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<User> CreateAsync(User user)
    {
        Validate(user);

        var entity = await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _context.Users.Where(predicate.Compile()).AsQueryable();

    public void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentException("Invalid full name");

        if (!Regex.IsMatch(user.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
            throw new ArgumentException("Invalid email");
    }
}
