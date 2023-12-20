using N90_HT1.Application.Common.Identity.Services;
using N90_HT1.Domain.Entities;
using N90_HT1.Persistence.Repositories.Interfaces;

namespace N90_HT1.Infrastructure.Common.Identity.Services;

public class UserSettingsService(IUserSettingsRepository userSettingsRepository) : IUserSettingsService
{
    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userSettingsRepository.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
    }

    public ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userSettingsRepository.CreateAsync(userSettings, saveChanges, cancellationToken);
    }
}