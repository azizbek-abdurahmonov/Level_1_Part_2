using Microsoft.AspNetCore.Mvc;
using N48_HT1.Models;
using N48_HT1.Services.Interfaces;

namespace N48_HT1.Controllers;

[Controller]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    
    
    private IUserService _userService;
    private IUserOrders _userOrders;

    public UsersController(IUserService userService, IUserOrders userOrders)
    {
        _userService = userService;
        _userOrders = userOrders;

    }

    [HttpGet]
    public IActionResult GetAllUsers([FromQuery] int pageToken, int pageSize)
    {
        var result = _userService.Get(user => true).Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateUser(User user)
    {
        var result = await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(GetById),new { userId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateUser([FromBody] User user)
    {
        await _userService.UpdateAsync(user);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _userService.GetByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet("{userId:Guid}/orders")]
    public IActionResult GetOrdersById([FromRoute] Guid userId)
    {
        var result = _userOrders.GetUserOrders(userId);
        return result.Any() ? Ok(result) : NotFound();
    }

}
