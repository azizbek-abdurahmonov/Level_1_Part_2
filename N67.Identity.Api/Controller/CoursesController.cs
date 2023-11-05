using Identity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using N67.Identity.Application.Common.Identity.Services;

namespace N67.Identity.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ILocationService _courseService;

    public CoursesController(ILocationService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Course course)
    {
        await _courseService.CreateAsync(course);

        return CreatedAtAction(nameof(GetById), new { CourseId = course.Id }, course);
    }

    [HttpGet("{courseId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid courseId)
    {
        return Ok(await _courseService.GetByIdAsync(courseId));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromBody] Course course)
    {
        await _courseService.UpdateAsync(course);

        return NoContent();
    }

    [HttpDelete("{courseId:guid}")]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid courseId)
    {
        await _courseService.DeleteAsync(courseId);

        return NoContent();
    }
}

