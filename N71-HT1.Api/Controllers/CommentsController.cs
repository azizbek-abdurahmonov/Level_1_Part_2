using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;

namespace N71_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public ValueTask<IActionResult> GetAll()
    {
        var result = _commentService.Get(comment => true, true);

        return new(result.Any() ? Ok(result) : NoContent());
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _commentService.GetByIdAsync(id);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Comment comment)
    {
        var result = await _commentService.CreateAsync(comment);

        return CreatedAtAction(nameof(GetById), new { CommentId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Comment comment)
    {
        var result = await _commentService.UpdateAsync(comment);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete([FromBody] Comment comment)
    {
        var result = await _commentService.DeleteAsync(comment);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
    {
        var result = await _commentService.DeleteByIdAsync(id);

        return result is not null ? Ok(result) : BadRequest();
    }
}
