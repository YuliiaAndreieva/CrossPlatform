using App.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/household-members")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class HouseholdMembersController : Controller
{
    private readonly ApiClient _apiClient;

    public HouseholdMembersController(
        ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    public async Task<IActionResult> GetAllHouseholdMembersAsCustomers()
    {
        try
        {
            var profiles = await _apiClient.GetAllHouseholdMembersAsync();
            return View("~/Views/Lab6/CustomerProfileList.cshtml", profiles);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
    
    [MapToApiVersion("2.0")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllHouseholdMembersDetails(int id)
    {
        try
        {
            var profile = await _apiClient.GetHouseholdMemberDetailsAsync(id);
            
            if (profile is null)
            {
                ModelState.AddModelError(string.Empty, "Household member not found.");
                return View("Error");
            }
            return View("~/Views/Lab7/HouseholdDetails.cshtml", profile);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
}