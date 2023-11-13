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

    public async ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _commentRepository.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment?> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _commentRepository.DeleteAsync(comment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _commentRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>> predicate, bool asNoTracking = false)
    {
        return _commentRepository.Get(predicate, asNoTracking);
    }

    public async ValueTask<Comment> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _commentRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public async ValueTask<ICollection<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _commentRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    }

    public async ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _commentRepository.UpdateAsync(comment, saveChanges, cancellationToken);
    }

    private void Validate(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Message))
        {
            throw new ArgumentException("Message cannot be empty!");
        }
    }
}
