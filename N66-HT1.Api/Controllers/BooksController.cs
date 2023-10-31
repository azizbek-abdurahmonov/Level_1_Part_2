using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N66_HT1.Application.Common.Constants;
using N66_HT1.Application.Common.DbManager.Services;
using N66_HT1.Domain.Entities;

namespace N66_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost, Authorize]
    public async ValueTask<IActionResult> Create([FromBody] Book book)
    {
        var userId = Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)!.Value);

        book.Id = default;
        book.AuthorId = userId;
        await _bookService.CreateAsync(book);

        return CreatedAtAction(nameof(GetById), new { BookId = book.Id }, book);
    }

    [HttpGet("{bookId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid bookId)
    {
        var result = await _bookService.GetByIdAsync(bookId);

        return Ok(result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Book book)
    {
        await _bookService.UpdateAsync(book);
        return NoContent();
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid userId)
    {
        await _bookService.DeleteAsync(userId);

        return NoContent();
    }
}