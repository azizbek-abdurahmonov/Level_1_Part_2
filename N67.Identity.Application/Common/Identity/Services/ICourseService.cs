using N67.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N67.Identity.Application.Common.Identity.Services;

public interface ICourseService
{
    ValueTask<Location> CreateAsync(Location course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> DeleteAsync(Location course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = null);

    ValueTask<Location?> GetByIdAsync(Guid id);

    ValueTask<Location> UpdateAsync(Location course, bool saveChanges = true, CancellationToken cancellationToken = default);
}
