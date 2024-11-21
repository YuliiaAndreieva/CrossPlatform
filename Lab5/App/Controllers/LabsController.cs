using App.Models;
using App.Validators;
using ClassLib.Lab1;
using ClassLib.Lab2;
using ClassLib.Lab3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
public class LabsController : Controller
{
    [HttpGet]
    public IActionResult First()
    {
        return View("FirstLab", new FirstLabModel());
    }

    [HttpPost]
    public IActionResult First(FirstLabModel model)
    {
        try
        {
            model.Result = Lab1Runner.Run(model.InputNumber);
        }
        catch (Exception ex)
        {
            model.ErrorMessage = "Exception occured: " + ex.Message;
        }

        return View("FirstLab",model);
    }
    
    [HttpGet]
    public IActionResult Second()
    {
        return View("SecondLab",new SecondLabViewModel());
    }

    [HttpPost]
    public IActionResult Second(SecondLabViewModel model)
    {
        try
        {
            var suppliers = model.Suppliers.Select(s => (ai: s.Packs, bi: s.Price)).ToList();
            model.Result = Lab2Runner.Run(model.TotalSocks, suppliers);
        }
        catch (Exception ex)
        {
            model.ErrorMessage = "Exception occured: " + ex.Message;
        }

        return View("SecondLab", model);
    }
    
    [HttpGet]
    public IActionResult Third()
    {
        return View("ThirdLab",new ThirdLabViewModel());
    }

    [HttpPost]
    public IActionResult Third(ThirdLabViewModel model)
    {
        try
        {
            var labyrinth1D = model.Labyrinth.SelectMany(row => row).ToArray();
            var keyPrices = new[] {
                model.KeyPrices['R'],
                model.KeyPrices['G'],
                model.KeyPrices['B'],
                model.KeyPrices['Y']
            };
            
            ThirdLabValidator.ValidateLabyrinth(model.Labyrinth);
            
            model.Result = Lab3Runner.Run(model.Rows, model.Cols, keyPrices, labyrinth1D);
        }
        catch (Exception ex)
        {
            model.ErrorMessage = $"Exception occured: {ex.Message}";
        }

        return View("ThirdLab", model);
    }
}