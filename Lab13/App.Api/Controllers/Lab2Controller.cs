using App.Api.Models;
using ClassLib.Lab2;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
[Route("api/lab2")]
public class Lab2Controller : ControllerBase
{
    [HttpPost]
    public IActionResult CalculateMinimumCost([FromBody] SecondLabViewModel model)
    {
        if (model.TotalSocks < 1 || model.Suppliers.Count != model.SupplierCount)
            return BadRequest("Invalid input data.");

        try
        {
            var suppliers = model.Suppliers.Select(s => (ai: s.Packs, bi: s.Price)).ToList();
            model.Result = Lab2Runner.Run(model.TotalSocks, suppliers);
            return Ok(model.Result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = $"Exception occurred: {ex.Message}" });
        }
    }
}