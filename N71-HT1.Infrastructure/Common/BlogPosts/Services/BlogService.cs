using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Infrastructure.Common.BlogPosts.Services;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;

    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(blog);

        return await _blogRepository.CreateAsync(blog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _blogRepository.DeleteAsync(blog, saveChanges, cancellationToken); 
    }

    public async ValueTask<Blog> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _blogRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>> predicate, bool asNoTracking = false)
    {
        return _blogRepository.Get(predicate, asNoTracking);
    }

    public async ValueTask<Blog> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _blogRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public async ValueTask<ICollection<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _blogRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    }

    public async ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(blog);

        return await _blogRepository.UpdateAsync(blog, saveChanges, cancellationToken);
    }

    private void Validate(Blog blog)
    {
        if (string.IsNullOrWhiteSpace(blog.Title))
            throw new ArgumentException("Title isn't valid!");

        if (string.IsNullOrWhiteSpace(blog.Description))
            throw new ArgumentException("Description is invalid!");
    }
}
