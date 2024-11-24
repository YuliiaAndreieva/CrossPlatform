using App.Api.Models;
using App.Validators;
using ClassLib.Lab3;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
[Route("api/lab3")]
public class Lab3Controller : ControllerBase
{
    [HttpPost]
    public IActionResult SolveLabyrinth([FromBody] ThirdLabViewModel model)
    {
        if (model.Rows < 1 || model.Cols < 1)
            return BadRequest("Invalid labyrinth dimensions.");

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
            return Ok(model.Result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = $"Exception occurred: {ex.Message}" });
        }
    }
}