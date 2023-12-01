using Mapster;
using Microsoft.AspNetCore.Mvc;
using N76_HT1.Models.Dtos;
using N76_HT1.Entities;
using N76_HT1.Services.Interfaces;

namespace N76_HT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> Get()
    {
        var result = userService.Get(user => true);

        return new(result.Any() ? Ok(result) : NoContent());
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
    {
        var foundUser = await userService.GetByIdAsync(id, true);

        return foundUser is not null ? Ok(foundUser) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] UserDto userDto)
    {
        var result = await userService.CreateAsync(userDto.Adapt<User>());

        return result is not null ? Ok(result) : NoContent();
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] UserDto userDto)
    {
        var result = await userService.UpdateAsync(userDto.Adapt<User>());

        return result is not null ? Ok(result) : NoContent();
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete([FromBody] Guid id)
    {
        var result = await userService.DeleteByIdAsync(id);

        return result is not null ? Ok(result) : NoContent();
    }
}
