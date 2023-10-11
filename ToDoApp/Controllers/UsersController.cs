using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers(int pageSize = 20, int pageToken = 1)
    {
        var users = _userService.Get(user => true).Skip((pageToken - 1) * pageSize).Take(pageSize);

        return users.Any() ? Ok(users) : NotFound();
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById(Guid id)
    {
        var result = await _userService.GetByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user)
    {
        await _userService.CreateAsync(user);
        return NoContent();
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] User user)
    {
        await _userService.UpdateAsync(user);
        return NoContent();
    }
}