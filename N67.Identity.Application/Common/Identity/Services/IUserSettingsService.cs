using Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N67.Identity.Application.Common.Identity.Services;

public interface IUserSettingsService
{
    IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>>? predicate = null);

    ValueTask<UserSettings?> GetByIdAsync(Guid id);

    ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> UpdateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> DeleteAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
