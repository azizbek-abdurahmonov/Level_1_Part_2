using N71_HT1.Domain.Entities;
using System.Dynamic;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories.Interfaces;

public interface IBlogRepository
{
    IQueryable<Blog> Get(Expression<Func<Blog, bool>> predicate, bool asNoTracking = false);

    ValueTask<ICollection<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Blog> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
