using Microsoft.AspNetCore.Mvc;

namespace HApp.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}