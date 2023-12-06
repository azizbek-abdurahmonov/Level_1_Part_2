using N80_HT1.Entities;
using N80_HT1.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N80_HT1.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null, bool asNoTracking = false)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }
}
