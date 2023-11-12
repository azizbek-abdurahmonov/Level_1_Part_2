using N71_HT1.Domain.Entities;
using System.Linq.Expressions;

namespace N71_HT1.Application.Common.BlogPosts.Services;

public interface ICommentService
{
    IQueryable<Comment> Get(Expression<Func<Comment, bool>> predicate, bool asNoTracking = false);

    ValueTask<ICollection<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Comment> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Comment?> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Comment?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
