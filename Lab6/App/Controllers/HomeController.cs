using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok();
    }
}