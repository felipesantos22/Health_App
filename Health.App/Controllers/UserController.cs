﻿using Health.Domain.Entities;
using Health.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HApp.Controllers;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IBaseRepository<User> _baseRepository;

    public UserController(IBaseRepository<User> baseRepository)
    {
        _baseRepository = baseRepository;
    }


    [HttpPost]
    public async Task<ActionResult<User>> Insert([FromBody] User obj)
    {
        var user = await _baseRepository.Insert(obj);
        return Ok(user);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<User>>> Select()
    {
        var user = await _baseRepository.Select();
        return Ok(user);
    }
}