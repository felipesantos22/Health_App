using Health.Domain.Entities;
using Health.Domain.Interfaces;
using Health.Service.Validators.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HApp.Controllers;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IBaseRepository<User> _baseRepository;
    private readonly UserValidatorEmail _userValidatorEmail;

    public UserController(IBaseRepository<User> baseRepository, UserValidatorEmail userValidatorEmail)
    {
        _baseRepository = baseRepository;
        _userValidatorEmail = userValidatorEmail;
    }


    [HttpPost]
    public async Task<ActionResult<User>> Insert([FromBody] User obj)
    {
        var name = _userValidatorEmail.UserNameExists(obj.Email);
        if (name)
        {
            return NotFound(new {message = "Email already registered."});
        }
        var user = await _baseRepository.Insert(obj);
        return Ok(user);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<User>>> Select()
    {
        var user = await _baseRepository.Select();
        return Ok(user);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> Select(int id)
    {
        var user = await _baseRepository.Select(id);
        if (user.ToString() == null)
        {
            return BadRequest(new {message = "User not found."});
        }
        return Ok(user);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<User>> Update(int id, [FromBody] User user)
    {
        var updateUser = await _baseRepository.Select(id);
        if (updateUser.ToString() == null) return NotFound(new { message = "User not found" });
        await _baseRepository.Update(id, user);
        return Ok(new { message = "User Updated" });
    }
}