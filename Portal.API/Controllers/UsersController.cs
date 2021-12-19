﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.API.Data;
using Portal.API.Dtos;
using System.Threading.Tasks;

namespace Portal.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _repo.GetUsers();
        var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
        return Ok(usersToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _repo.GetUser(id);
        var userToReturn = _mapper.Map<UserForDetailedDto>(user);
        return Ok(userToReturn);
    }
}
