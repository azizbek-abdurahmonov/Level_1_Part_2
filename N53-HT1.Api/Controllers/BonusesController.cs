using Microsoft.AspNetCore.Mvc;
using N53_HT1.Api.Interfaces;
using N53_HT1.Api.Models;

namespace N53_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BonusesController : ControllerBase
{
    private readonly IBonusService _bonusService;

    public BonusesController(IBonusService bonusService)
    {
        _bonusService = bonusService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _bonusService.Get(bonus => true);
        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(Bonus bonus)
    {
        var result = await _bonusService.CreateAsync(bonus);
        return Ok(result);
    }
}
