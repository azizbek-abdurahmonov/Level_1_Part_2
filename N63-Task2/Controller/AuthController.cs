using Microsoft.AspNetCore.Mvc;
using N63_Task2.Models.Dtos;
using N63_Task2.Services;

namespace N63_Task2.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
    {
        var result = await _authService.RegisterAsync(registrationDetails);

        return Ok(result);
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var result = await _authService.LoginAsync(loginDetails);

        return Ok(result);
    }
}
