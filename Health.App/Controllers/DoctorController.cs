using Health.Domain.Entities;
using Health.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HApp.Controllers;

[Route("api/v1/doctor")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IBaseRepository<Doctor> _baseRepository;

    public DoctorController(IBaseRepository<Doctor> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Doctor>> Insert([FromBody] Doctor obj)
    {
        var doctor = await _baseRepository.Insert(obj);
        return Ok(doctor);
    }

    [HttpGet]
    public async Task<ActionResult<List<Doctor>>> Select()
    {
        var doctor = await _baseRepository.Select();
        return Ok(doctor);
    }
}