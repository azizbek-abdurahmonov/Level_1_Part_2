using Microsoft.AspNetCore.Mvc;
using N67.Identity.Application.Common.Identity.Services;

namespace N67.Identity.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("{locationId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid locationId)
    {
        var result = await _locationService.GetByIdAsync(locationId);
    }
}
