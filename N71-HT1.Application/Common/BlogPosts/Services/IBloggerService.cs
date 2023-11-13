using N71_HT1.Domain.Entities;

namespace N71_HT1.Application.Common.BlogPosts.Services;

public interface IBloggerService
{
    ValueTask<IQueryable<User>> GetPopularBloggers();
}
