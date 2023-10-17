using System.Linq.Expressions;
using ToDoApp.Models;

namespace ToDoApp.Services.Interfaces;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids);

    ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellation = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UploadImageAsync(Guid userId, UploadImageDto image, CancellationToken cancellationToken = default);
}