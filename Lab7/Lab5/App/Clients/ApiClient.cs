using App.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace App.Clients;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CustomerProfileViewModel>> GetCustomerProfilesAsync()
    {
        var response = await _httpClient.GetAsync("/api/customer-profiles");
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<List<CustomerProfileViewModel>>())!;
    }

    public async Task<CustomerProfileDetailsViewModel?> GetCustomerDetailsAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/customer-profiles/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerProfileDetailsViewModel>();
    }
    
    public async Task<List<RefContactOutcomeViewModel>> GetRefContactOutcomesAsync()
    {
        var response = await _httpClient.GetAsync("/api/ref-contact-outcomes");

        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<List<RefContactOutcomeViewModel>>())!;
    }

    public async Task<RefContactOutcomeViewModel?> GetRefContactOutcomeDetailsAsync(int code)
    {
        var response = await _httpClient.GetAsync($"/api/ref-contact-outcomes/{code}");

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<RefContactOutcomeViewModel>();
    }
    
    public async Task<List<CustomerProductHoldingViewModel>> GetCustomerProductHoldingsAsync()
    {
        var response = await _httpClient.GetAsync("/api/customer-product-holdings");

        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<List<CustomerProductHoldingViewModel>>())!;
    }

    public async Task<CustomerProductHoldingDetailsViewModel?> GetCustomerProductHoldingDetailsAsync(int customerId, int productId)
    {
        var response = await _httpClient.GetAsync($"/api/customer-product-holdings/{customerId}/{productId}");

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerProductHoldingDetailsViewModel>();
    }
    
    public async Task<List<SpecialOfferViewModel>?> GetSpecialOffersAsync()
    {
        var response = await _httpClient.GetAsync("/api/special-offers");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<SpecialOfferViewModel>>();
    }
    
    public async Task<List<CustomerFullModel>> SearchCustomersAsync(string query)
    {
        var response = await _httpClient.GetAsync($"/api/customers/search?{query}");
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<List<CustomerFullModel>>())!;
    }
    
    public async Task<List<CustomerProfileViewModel>?> GetAllHouseholdMembersAsync()
    {
        var response = await _httpClient.GetAsync($"/api/household-members");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<CustomerProfileViewModel>>();
    }
    
    public async Task<HouseholdMemberViewModel?> GetHouseholdMemberDetailsAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/household-members/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<HouseholdMemberViewModel>();
    }
}