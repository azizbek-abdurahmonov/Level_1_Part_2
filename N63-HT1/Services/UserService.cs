using N63_HT1.DataAccess;
using N63_HT1.Interfaces;
using N63_HT1.Models.Entities;

namespace N63_HT1.Services;

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

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public IQueryable<User> GetAll()
        => _context.Users.AsQueryable();

    public ValueTask<User> GetByIdAsync(Guid id)
        => new ValueTask<User>(_context.Users.FirstOrDefault(user => user.Id == id)!);

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentException("Full name isn't valid!");

        if (!user.Email.EndsWith("@gmail.com"))
            throw new Exception("Only '@gmail.com' domen is  supported!");
    }
}
