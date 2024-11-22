using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class Lab6Controller : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}