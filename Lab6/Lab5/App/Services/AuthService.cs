using App.Helpers;
using App.Models;
using App.Responces;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace App.Services;

public class AuthService : IAuthService
{
    private readonly AuthOptions _authOptions;
    private readonly ILogger<AuthService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    
    public AuthService(IOptions<AuthOptions> authOptions,
        ILogger<AuthService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _authOptions = authOptions.Value;
    }
    public async Task<bool> CreateUserAsync(RegisterViewModel model)
    {
        try
        {
            _logger.LogInformation("Attempting to create user with email: {Email}", model.Email);
            var managementClient = await GetManagementApiClientAsync();
            var userCreateRequest = new UserCreateRequest
            {
                Email = model.Email,
                Password = model.Password,
                Connection = "Username-Password-Authentication",
                EmailVerified = true,
                UserMetadata = new
                {
                    full_name = model.FullName,
                    phone_number = $"+380{model.PhoneNumber}",
                    username = model.Username,
                },
            };

            await managementClient.Users.CreateAsync(userCreateRequest);
            _logger.LogInformation("User created successfully with email: {Email}", model.Email);
            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating user with email: {Email}", model.Email);
            return false;
        }
    }

    public async Task<User?> GetUserAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            _logger.LogWarning("GetUserAsync called with an empty or null ID");
            return null;
        }

        try
        {
            _logger.LogInformation("Attempting to retrieve user with ID: {Id}", id);

            var managementClient = await GetManagementApiClientAsync();
            var user = await managementClient.Users.GetAsync(id);

            _logger.LogInformation("User retrieved successfully with ID: {Id}", id);
            return user;
        }
        catch (ApiException apiEx)
        {
            _logger.LogError(apiEx, "API error occurred while retrieving user with ID: {Id}", id);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occurred while retrieving user with ID: {Id}", id);
            return null;
        }
    }

    private async Task<IManagementApiClient> GetManagementApiClientAsync()
    {
        try
        {
            _logger.LogInformation("Initializing Management API client for domain: {Domain}", _authOptions.Domain);

            var auth0Client = new AuthenticationApiClient(new Uri($"https://{_authOptions.Domain}"));
            var tokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _authOptions.ClientId,
                ClientSecret = _authOptions.ClientSecret,
                Audience = $"https://{_authOptions.Domain}/api/v2/"
            };
            var token = await auth0Client.GetTokenAsync(tokenRequest);

            _logger.LogInformation("Management API client initialized successfully.");
            return new ManagementApiClient(
                token.AccessToken,
                new Uri($"https://{_authOptions.Domain}/api/v2"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while initializing Management API client.");
            throw;
        }
    }
    
    public async Task<string> GetApiAccessTokenAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var tokenEndpoint = $"https://{_authOptions.Domain}/oauth/token";

        var response = await client.PostAsJsonAsync(tokenEndpoint, new
        {
            grant_type = "client_credentials",
            client_id = _authOptions.ClientId,
            client_secret = _authOptions.ClientSecret,
            audience = "lab6Api"
        });

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response Status: {response.StatusCode}");
        Console.WriteLine($"Response Content: {content}");

        var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return result?.AccessToken ?? throw new InvalidOperationException("Failed to get access token.");
    }
}