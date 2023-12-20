using N90_HT1.Domain.Entities;
using N90_HT1.Persistence.Caching.Brokers;
using N90_HT1.Persistence.DataContexts;
using N90_HT1.Persistence.Repositories.Interfaces;

namespace N90_HT1.Persistence.Repositories;

public class UserSettingsRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserSettings, IdentityDbContext>(dbContext, cacheBroker), IUserSettingsRepository
{
    public new ValueTask<UserSettings?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public new ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(userSettings, saveChanges, cancellationToken);
    }
}