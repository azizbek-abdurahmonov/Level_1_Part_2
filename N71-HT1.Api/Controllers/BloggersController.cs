using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N71_HT1.Api.Common.Models;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;
using N71_HT1.Persistence.DataContexts;

namespace N71_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BloggersController : ControllerBase
{
    private readonly IUserService _userService;

    private readonly BlogPostsDbContext _dbContext;

    //O'zgartirilishi mumkin , DbContextni inject qildim query qilish uchun
    public BloggersController(IUserService userService, BlogPostsDbContext dbContext)
    {
        _userService = userService;
        _dbContext = dbContext;
    }

    [HttpGet("popular")]
    public ValueTask<IActionResult> GetPopular([FromQuery] FilterPagination paginationOptions)
    {
        var popularBloggersQuery = _dbContext.Users
            .Include(user => user.BlogPosts)
            .Include(user => user.Comments)
            .Where(user => user.BlogPosts.Count >= 1
                       && user.BlogPosts.All(blog => blog.Comments.Count >= 5)) // 5 ni 20 ga o'zgartiraman
            .OrderBy(user => user.BlogPosts.Count)
            .Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize)
            .Take(paginationOptions.PageSize);

        return new(popularBloggersQuery.Any() ? Ok(popularBloggersQuery) : NoContent());
    }
}
