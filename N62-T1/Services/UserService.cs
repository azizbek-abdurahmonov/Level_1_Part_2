using N62_T1.Models;

namespace N62_T1.Services;

public class UserService : IUserService
{
    private List<User> _users;

    public UserService()
    {
        _users = new List<User>();
    }

    public ValueTask<User> CreateAsync(User user)
    {
        _users.Add(user);

        return new ValueTask<User>(user);
    }

    public ValueTask<User> GetAsync(Guid userId)
    {
        var found = _users.FirstOrDefault(user => user.Id == userId);

        if (found == null) throw new ArgumentException(nameof(User));


        return new ValueTask<User>(found);
    }
}
