using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace N71_HT1.Infrastructure.Common.BlogPosts.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        return await _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User?> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _userRepository.DeleteAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate, bool asNoTracking = false)
    {
        return _userRepository.Get(predicate, asNoTracking);
    }

    public async ValueTask<User> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public async ValueTask<ICollection<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _userRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        return await _userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    private void Validate(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));

        if (string.IsNullOrWhiteSpace(user.FirstName)
            || string.IsNullOrWhiteSpace(user.LastName))
        {
            throw new ArgumentException("Invalid name informations");
        }

        if (!user.EmailAddress.EndsWith("@gmail.com"))
            throw new ArgumentException("Only gmail domen supported!");

    }
}
