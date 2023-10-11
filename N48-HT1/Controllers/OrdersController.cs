using Microsoft.AspNetCore.Mvc;
using N48_HT1.Models;
using N48_HT1.Services.Interfaces;

namespace N48_HT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetAllOrders([FromQuery] int pageToken, [FromQuery] int pageSize)
    {
        var result = _orderService.Get(order => true);
        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpPost("order")]
    public async ValueTask<IActionResult> CreateAsync([FromBody] Order order)
    {
        var result = await _orderService.CreateAsync(order);
        return CreatedAtAction(nameof(result), new { userId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromBody] Order order)
    {
        await _orderService.UpdateAsync(order);
        return NoContent();
    }

    [HttpGet("{orderId}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid orderId)
    {
        var result = await _orderService.GetByIdAsync(orderId);
        return result is not null ? Ok(result) : NotFound();
    }

    public IActionResult Result(Guid userid)
    {
        throw new NotImplementedException();
    }
}
