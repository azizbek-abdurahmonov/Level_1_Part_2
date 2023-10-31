using Microsoft.AspNetCore.Mvc;
using N66_HT1.Application.Common.DbManager.Services;
using N66_HT1.Domain.Entities;

namespace N66_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user)
    {
        var result = await _userService.CreateAsync(user);

        return CreatedAtAction(nameof(GetById), new { UserId = result.Id }, result);
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
    {
        var result = await _userService.GetByIdAsync(userId);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] User user)
    {
        var result = await _userService.UpdateAsync(user);

        return NoContent();
    }

    [HttpDelete("userId:guid")]
    public async ValueTask<IActionResult> Delete(Guid userId)
    {
        await _userService.DeleteAsync(userId);

        return NoContent();
    }
}
