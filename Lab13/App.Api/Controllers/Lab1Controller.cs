using App.Api.Models;
using ClassLib.Lab1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
[Route("api/lab1")]
public class Lab1Controller : ControllerBase
{
    [HttpPost]
    public IActionResult CalculateNthSequenceMember([FromBody]int inputNumber)
    {
        Console.WriteLine($"IN CONTROLLER, The {inputNumber}-th number is: {inputNumber}");
        if (inputNumber < 1)
            return BadRequest("InputNumber must be greater than or equal to 1.");

        try
        {
            var result = Lab1Runner.Run(inputNumber);
            Console.WriteLine($"IN CONTROLLER, The {inputNumber}-th number in the sequence is: {result}");
            return Ok((int)result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = $"Exception occurred: {ex.Message}" });
        }
    }
}