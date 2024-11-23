using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class Lab7Controller : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}