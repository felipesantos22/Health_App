using Health.Domain.Entities;
using Health.Infra.Repository;
using Health.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace HApp.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthRepository _authRepository;

    public AuthController(AuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost]
    public async Task<ActionResult<User>> AuthUser([FromBody] User user)
    {
        var obj = await _authRepository.AuthUser(user.Email, user.Password);
        if (obj == null)
        {
            return BadRequest(new { message = "Email or password not found." });
        }
        var token = TokenService.GenerateToken(obj);
        return Ok(new { Token = token });
    }
}