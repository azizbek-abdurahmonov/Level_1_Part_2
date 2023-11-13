using Microsoft.EntityFrameworkCore;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;
using N71_HT1.Persistence.DataContexts;

namespace N71_HT1.Infrastructure.Common.BlogPosts.Services;

public class BloggerService : IBloggerService
{
    private readonly BlogPostsDbContext _dbContext;

    public BloggerService(BlogPostsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ValueTask<IQueryable<User>> GetPopularBloggers()
    {
        return new(_dbContext.Users
            .Include(user => user.BlogPosts)
            .Where(user => user.BlogPosts.Count >= 5
                && user.BlogPosts.All(blog => blog.Comments.Count >= 20))
            .OrderBy(user => user.BlogPosts.Count));
    }
}
