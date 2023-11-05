using N67.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N67.Identity.Application.Common.Identity.Services;

public interface ILocationService
{
    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = null);

    ValueTask<Location?> GetByIdAsync(Guid id);

    ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> DeleteAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
