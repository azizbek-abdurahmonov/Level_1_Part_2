using Microsoft.AspNetCore.Mvc;
using N70.Identity.Application.Common.Identity.Services;

namespace N70.Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut("verification/{token}")]
    public async ValueTask<IActionResult> Verificate([FromRoute] string token)
    {
        var result = await _accountService.VerificateUserAsync(token);

        return Ok(result);
    }
}