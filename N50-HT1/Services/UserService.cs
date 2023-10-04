using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services;

public class UserService : IUserService
{
    private List<User> _users;

    public UserService(List<User> users)
    {
        _users = users;
    }

    public User Create(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user), "User is null");

        _users.Add(user);
        return user;
    }

    public User Update(User user)
    {
        var foundedUser = _users.FirstOrDefault(x => x.Id == user.Id);
        if (foundedUser == null) throw new InvalidOperationException("User not found!");

        foundedUser.FirstName = user.FirstName;
        foundedUser.LastName = user.LastName;
        foundedUser.EmailAddress = user.EmailAddress;

        return foundedUser;
    }

    public User Get(Guid id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public void Delete(Guid id)
    {
        var foundedUser = Get(id);
        if (foundedUser == null) throw new InvalidOperationException("User not found!");

        _users.Remove(foundedUser);
    }

    public void Delete(User user)
    {
        _users.Remove(user);
    }
}