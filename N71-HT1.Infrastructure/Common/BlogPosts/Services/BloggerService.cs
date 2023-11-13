using Microsoft.EntityFrameworkCore;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;

namespace N71_HT1.Infrastructure.Common.BlogPosts.Services;

public class BloggerService : IBloggerService
{
    private readonly IUserService _userService;

    public BloggerService(IUserService userService)
    {
        _userService = userService;
    }

    public ValueTask<IQueryable<User>> GetPopularBloggers()
    {
        return new(_userService.Get(user => true)
            .Include(user => user.BlogPosts)
            .Where(user => user.BlogPosts.Count >= 5 && user.BlogPosts.All(blog => blog.Comments.Count >= 20))
            .OrderBy(user => user.BlogPosts.Count));
    }
}
