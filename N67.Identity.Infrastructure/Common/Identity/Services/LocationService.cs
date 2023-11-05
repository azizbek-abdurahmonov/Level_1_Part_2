using System.Linq.Expressions;
using N67.Identity.Application.Common.Identity.Services;
using N67.Identity.Domain.Entities;
using N67.Identity.Persistence.DataAccess;

namespace N67.Identity.Infrastructure.Common.Identity.Services;

public class LocationService : ILocationService
{
    private readonly AppDbContext _dbContext;

    public LocationService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.Locations.AddAsync(location);
    }

    public ValueTask<Location> DeleteAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Location> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Location?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}