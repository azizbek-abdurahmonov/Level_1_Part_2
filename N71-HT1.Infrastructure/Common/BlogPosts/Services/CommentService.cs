using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Infrastructure.Common.BlogPosts.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment?> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>> predicate, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ICollection<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private void Validate(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Message))
        {
            throw new ArgumentException("Message cannot be empty!");
        }
    }
}
