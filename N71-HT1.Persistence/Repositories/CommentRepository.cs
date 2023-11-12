using N71_HT1.Domain.Entities;
using N71_HT1.Persistence.DataContexts;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories;

public class CommentRepository : EntityRepositoryBase<Comment, BlogPostsDbContext>, ICommentRepository
{
    public CommentRepository(BlogPostsDbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public ValueTask<Comment?> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(comment, saveChanges, cancellationToken);
    }

    public ValueTask<Comment?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<ICollection<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    }

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(comment, saveChanges, cancellationToken);
    }
}
