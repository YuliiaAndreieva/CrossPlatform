using System.Net.Http.Headers;
using App.Clients;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.Controllers;

public class CustomerProfileController : Controller
{
    private readonly ApiClient _apiClient;

    public CustomerProfileController(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    public async Task<IActionResult> Index()
    {
        try
        {
            var profiles = await _apiClient.GetCustomerProfilesAsync();
            Console.WriteLine(profiles);
            return View("~/Views/Lab6/CustomerProfileList.cshtml", profiles);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
   
    [Route("CustomerProfiles/Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var profile = await _apiClient.GetCustomerDetailsAsync(id);
            return View("~/Views/Lab6/CustomerProfileDetails.cshtml", profile);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
}