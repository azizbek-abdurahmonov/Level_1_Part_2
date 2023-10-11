using Microsoft.AspNetCore.Mvc;
using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountsController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateUser([FromBody] User user)
    {
        var result = await _userService.CreateAsync(user);

        return Ok(result);
    }
}