using Microsoft.AspNetCore.Mvc;
using N80_HT1.Common.Query;
using N80_HT1.Entities;
using N80_HT1.Services;

namespace N80_HT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> Get()
    {
        var result = userService.Get();

        return new(result.Any() ? Ok(result) : NoContent());
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await userService.GetByIdAsync(id, cancellationToken: HttpContext.RequestAborted);

        return result is not null ? Ok(result) : NoContent();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user)
    {
        var result = await userService.CreateAsync(user, cancellationToken: HttpContext.RequestAborted);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] User user, CancellationToken cancellationToken)
    {
        var result = await userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return result is not null ? Ok(result) : NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteByIdAsync(id, cancellationToken: cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpGet("byQuerySpecification")]
    public ValueTask<IActionResult> GetBySpecification()
    {
        var querySpecification = new QuerySpecification<User>(15, 1);

        querySpecification.FilteringOptions.Add(user => user.FirstName.Length >= 5);
        querySpecification.FilteringOptions.Add(user => user.LastName.Length <= 20);

        return new(Ok());
    }
}
