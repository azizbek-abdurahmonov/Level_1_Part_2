using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private IUserOrderService _userOrderService;

    public OrdersController(IUserOrderService userOrderService)
    {
        _userOrderService = userOrderService;
    }

    [HttpGet("/by-user/{userId:guid}")]
    public IActionResult GetByUser(Guid userId)
    {
        return Ok(_userOrderService.GetUserOrdersByUserId(userId));
    }
}