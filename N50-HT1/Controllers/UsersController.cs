using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUserById(Guid id)
    {
        var result = _userService.Get(id);
        return result is not null ? Ok(result) : NotFound();
    }
}