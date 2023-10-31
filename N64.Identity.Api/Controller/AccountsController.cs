using Microsoft.AspNetCore.Mvc;
using N64.Identity.Application.Common.Identity.Services;

namespace N64.Identity.Api.Controller;

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
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
    {
        var result = await _accountService.VerificateAsync(token);
        return Ok(result);
    }
}
