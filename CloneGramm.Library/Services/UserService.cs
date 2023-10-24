using CloneGramm.Library.DataAccess;
using CloneGramm.Library.Interfaces;
using CloneGramm.Library.Models;
using System.Linq.Expressions;

namespace CloneGramm.Library.Services;

public class UserService : IUserService
{
    private readonly IDataContext _context;

    public UserService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<User> CreateAsync(User user)
    {
        var entity = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async ValueTask DeleteAsync(User user)
    {
        await _context.Users.RemoveAsync(user);
        await _context.SaveChangesAsync();
    }

    public async ValueTask DeleteById(Guid id)
    {
        var foundUser = await GetByIdAsync(id);
        await _context.Users.RemoveAsync(foundUser);
        await _context.SaveChangesAsync();
    }

    public IQueryable<User> GetAsync(Expression<Func<User, bool>> predicate)
        => _context.Users.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<User> GetByIdAsync(Guid userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public ValueTask<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
