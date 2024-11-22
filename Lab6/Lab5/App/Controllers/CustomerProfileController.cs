using System.Net.Http.Headers;
using App.Clients;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.Controllers;

[Authorize]
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
    
    [HttpGet]
    public async Task<IActionResult> Filter()
    {
        try
        {
            var specialOffers = await _apiClient.GetSpecialOffersAsync();

            var filterViewModel = new CustomerFilterViewModel
            {
                SpecialOffers = specialOffers!
            };

            return View("~/Views/Lab6/CustomerFilterList.cshtml", filterViewModel);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Search(CustomerFilterViewModel filters)
    {
        try
        {
            var queryParameters = new List<string>();

            if (filters.ContactStartDate.HasValue && filters.ContactEndDate.HasValue)
                queryParameters.Add($"contactStartDate={filters.ContactStartDate.Value:o}&contactEndDate={filters.ContactEndDate.Value:o}");
            if (filters.SpecialOfferId.HasValue)
                queryParameters.Add($"specialOfferId={filters.SpecialOfferId.Value}");
            if (filters.ProductStartDate.HasValue && filters.ProductEndDate.HasValue)
                queryParameters.Add($"productStartDate={filters.ProductStartDate.Value:o}&productEndDate={filters.ProductEndDate.Value:o}");

            var queryString = string.Join("&", queryParameters);
            var customers = await _apiClient.SearchCustomersAsync(queryString);

            return View("~/Views/Lab6/CustomerSearchResults.cshtml", customers);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
}