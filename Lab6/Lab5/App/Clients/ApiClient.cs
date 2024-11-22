using App.Models;

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
        return await response.Content.ReadFromJsonAsync<List<CustomerProfileViewModel>>();
    }

    public async Task<CustomerProfileDetailsViewModel?> GetCustomerDetailsAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/customer-profiles/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerProfileDetailsViewModel>();
    }
}