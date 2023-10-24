using Mapster;
using Microsoft.AspNetCore.Mvc;
using N62_T1.Models;
using N62_T1.Models.DTOs;
using N62_T1.Services;

namespace N62_T1.Controllers;

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
    public async ValueTask<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
        var user = userDto.Adapt<User>();
        user.Id = Guid.NewGuid();
        user.CreatedDate = DateTime.Now;

        await _userService.CreateAsync(user);

        return Ok(user);
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> Get([FromRoute] Guid userId)
    {
        var user = await _userService.GetAsync(userId);
        return Ok(user.Adapt<UserDto>());
    }
}
