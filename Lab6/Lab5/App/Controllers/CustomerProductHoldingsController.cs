using App.Clients;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class CustomerProductHoldingsController : Controller
{
    private readonly ApiClient _apiClient;

    public CustomerProductHoldingsController(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var productHoldings = await _apiClient.GetCustomerProductHoldingsAsync();
            return View("~/Views/Lab6/CustomerProductHoldingsList.cshtml", productHoldings);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    [HttpGet("CustomerProductHoldings/Details/{customerId}/{productId}")]
    public async Task<IActionResult> Details(int customerId, int productId)
    {
        try
        {
            var productHoldingDetails = await _apiClient.GetCustomerProductHoldingDetailsAsync(customerId, productId);
            return View("~/Views/Lab6/CustomerProductHoldingDetails.cshtml", productHoldingDetails);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
}