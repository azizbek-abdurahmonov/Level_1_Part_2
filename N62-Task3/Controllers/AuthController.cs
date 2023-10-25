using Microsoft.AspNetCore.Mvc;
using N62_Task3.Models.Dtos;
using N62_Task3.Models.Entity;
using N62_Task3.Services;

namespace N62_Task3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    public AuthController(TokenGeneratorService tokenGeneratorService)
    {
        _tokenGeneratorService = tokenGeneratorService;
    }

    [HttpPost]
    public ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        //Bu yerda bazadan user topib olinadi
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "",
            LastName = "",
            Email = loginDetails.EmailAddress,
            Password = loginDetails.Password,
        };
        //

        var token = _tokenGeneratorService.GetToken(user);

        return new ValueTask<IActionResult>(Ok(token));
    }
}
