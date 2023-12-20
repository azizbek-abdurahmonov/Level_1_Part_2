using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using N90_HT1.Application.Common.Identity.Models;
using N90_HT1.Application.Common.Identity.Services;

namespace N90_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMapper mapper, IAuthAggregationService authAggregationService) : ControllerBase
{
    [HttpPost("sign-up")]
    public async ValueTask<IActionResult> SignUp([FromBody] SignUpDetails signUpDetails, CancellationToken cancellationToken)
    {
        var result = await authAggregationService.SignUpAsync(signUpDetails, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}