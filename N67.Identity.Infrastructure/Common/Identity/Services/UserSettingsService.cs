using Identity.Domain.Entities;
using N67.Identity.Application.Common.Identity.Services;
using N67.Identity.Persistence.DataAccess;
using System.Linq.Expressions;

namespace N67.Identity.Infrastructure.Common.Identity.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly AppDbContext _dbContext;

    public UserSettingsService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.UserSettings.AddAsync(userSettings);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return userSettings;
    }

    public ValueTask<UserSettings> DeleteAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
        => DeleteAsync(userSettings.Id, saveChanges, cancellationToken);

    public async ValueTask<UserSettings> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(id)
            ?? throw new InvalidOperationException("User not found!");

        _dbContext.UserSettings.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }

    public IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>>? predicate = null)
        => predicate != null ? _dbContext.UserSettings.Where(predicate) : _dbContext.UserSettings;

    public async ValueTask<UserSettings?> GetByIdAsync(Guid id)
        => await _dbContext.UserSettings.FindAsync(id);

    public async ValueTask<UserSettings> UpdateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(userSettings.Id)
            ?? throw new InvalidOperationException("User not found!");

        found.DarkModeEnabled = userSettings.DarkModeEnabled;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return userSettings;
    }
}
