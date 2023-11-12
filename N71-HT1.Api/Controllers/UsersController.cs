using Microsoft.AspNetCore.Mvc;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Domain.Entities;

namespace N71_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ValueTask<IActionResult> GetAll()
    {
        var result = _userService.Get(user => true, true);
        return new(result.Any() ? Ok(result) : NoContent());
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _userService.GetByIdAsync(id, cancellationToken: HttpContext.RequestAborted);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user)
    {
        var result = await _userService.CreateAsync(user, cancellationToken: HttpContext.RequestAborted);

        return CreatedAtAction(nameof(Get), new { UserId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] User user)
    {
        var result = await _userService.UpdateAsync(user, cancellationToken: HttpContext.RequestAborted);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete([FromBody] User user)
    {
        var result = await _userService.DeleteAsync(user, cancellationToken: HttpContext.RequestAborted);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
    {
        var result = await _userService.DeleteByIdAsync(id);

        return result is not null ? Ok(result) : BadRequest();
    }
}
