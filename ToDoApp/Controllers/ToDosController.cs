using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDosController : ControllerBase
{
    private ITodoService _todoService;

    public ToDosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public IActionResult Get(int pageSize = 10, int pageToken = 1)
    {
        var result = _todoService.Get(x => true).Skip((pageToken - 1) * pageSize).Take(pageSize);
        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("id:guid")]
    public async ValueTask<IActionResult> Get(Guid id)
    {
        var result = await _todoService.GetByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] ToDo toDo)
    {
        await _todoService.CreateAsync(toDo);
        return NoContent();
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] ToDo toDo)
    {
        await _todoService.UpdateAsync(toDo);
        return NoContent();
    }
}