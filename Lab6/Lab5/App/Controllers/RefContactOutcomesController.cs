using App.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
public class RefContactOutcomesController : Controller
{
    private readonly ApiClient _apiClient;

    public RefContactOutcomesController(
        ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var outcomes = await _apiClient.GetRefContactOutcomesAsync();
            return View("~/Views/Lab6/RefContactOutcomesList.cshtml", outcomes);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    [HttpGet("RefContactOutcomes/Details/{code}")]
    public async Task<IActionResult> Details(int code)
    {
        try
        {
            var outcome = await _apiClient.GetRefContactOutcomeDetailsAsync(code);
            return View("~/Views/Lab6/RefContactOutcomeDetails.cshtml", outcome);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
}