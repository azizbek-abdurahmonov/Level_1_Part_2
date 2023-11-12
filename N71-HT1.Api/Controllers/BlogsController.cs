using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;

namespace N71_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public ValueTask<IActionResult> GetAll()
    {
        var result = _blogService.Get(blog => true, true);

        return new(result.Any() ? Ok(result) : NoContent());
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _blogService.GetByIdAsync(id, true);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Blog blog)
    {
        var result = await _blogService.CreateAsync(blog);

        return CreatedAtAction(nameof(GetById), new { BlogId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Blog blog)
    {
        var result = await _blogService.UpdateAsync(blog);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete([FromBody] Blog blog)
    {
        var result = await _blogService.DeleteAsync(blog);

        return result is not null ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
    {
        var result = await _blogService.DeleteByIdAsync(id);

        return result is not null ? Ok(result) : BadRequest();
    }
}
