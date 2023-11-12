using System.Linq.Expressions;
using System.Text.RegularExpressions;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.Repositories.Interfaces;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        return _userRepository.Get(predicate);
    }

    public async ValueTask<User> CreateAsync(User user)
    {
        await ValidateAsync(user);
        return await _userRepository.CreateAsync(user);
    }

    public ValueTask<User> GetByIdAsync(Guid id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public ValueTask<User> UpdateAsync(User user)
    {
        return _userRepository.UpdateAsync(user);
    }

    private ValueTask ValidateAsync(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName)
            || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentException("Invalid name informations");

        if (!Regex.IsMatch(user.EmailAddress, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
            throw new ArgumentException("Invalid email address!");

        if (_userRepository.Get(dbUser => dbUser.EmailAddress == user.EmailAddress).Any())
            throw new InvalidOperationException("User with this email already exists!");

        return ValueTask.CompletedTask;
    }
}