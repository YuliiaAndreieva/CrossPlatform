using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
public class Lab6Controller : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}