using Microsoft.AspNetCore.Mvc;
using N66_HT1.Application.Common.DbManager.Models;
using N66_HT1.Application.Common.DbManager.Services;

namespace N66_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
    {
        var result = await _authService.RegisterAsync(registrationDetails);

        return result ? Ok() : BadRequest();
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var result = await _authService.LoginAsync(loginDetails);

        return Ok(result);
    }
}
