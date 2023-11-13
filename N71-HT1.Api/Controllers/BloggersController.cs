using Microsoft.AspNetCore.Mvc;
using N71_HT1.Api.Common.Models;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;
namespace N71_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BloggersController : ControllerBase
{
    private readonly IBloggerService _bloggerService;

    public BloggersController(IBloggerService bloggerService)
    {
        _bloggerService = bloggerService;
    }

    [HttpGet("popular")]
    public async ValueTask<IActionResult> GetPopular([FromQuery] FilterPagination paginationOptions)
    {
        IQueryable<User>? result = await _bloggerService.GetPopularBloggers();

        return result.Any() ?
            Ok(result.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize)
            .Take(paginationOptions.PageSize))
            : NoContent();
    }
}
