using Microsoft.EntityFrameworkCore;
using N71_HT1.Domain.Entities;
using N71_HT1.Persistence.DataContexts;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories;

public class BlogRepository : EntityRepositoryBase<Blog, BlogPostsDbContext>, IBlogRepository
{
    public BlogRepository(BlogPostsDbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(blog, saveChanges, cancellationToken);  
    }

    public ValueTask<Blog?> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(blog, saveChanges, cancellationToken);  
    }

    public ValueTask<Blog?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);  
    }

    public ValueTask<ICollection<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdsAsync(ids, asNoTracking, cancellationToken);    
    }

    public ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(blog, saveChanges, cancellationToken);
    }
}
