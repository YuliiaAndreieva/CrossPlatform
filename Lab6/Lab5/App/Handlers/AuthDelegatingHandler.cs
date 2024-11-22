using App.Responces;

namespace App.Handlers;

public class AuthDelegatingHandler : DelegatingHandler
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private string _accessToken;

    public AuthDelegatingHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(_accessToken))
        {
            _accessToken = await GetAccessTokenAsync();
        }

        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);

        return await base.SendAsync(request, cancellationToken);
    }
    
    private async Task<string> GetAccessTokenAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var tokenEndpoint = $"https://{_configuration["Auth0:Domain"]}/oauth/token";

        var response = await client.PostAsJsonAsync(tokenEndpoint, new
        {
            grant_type = "client_credentials",
            client_id = _configuration["Auth0:ClientId"],
            client_secret = _configuration["Auth0:ClientSecret"],
            audience = "lab6Api"
        });

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return result?.AccessToken ?? throw new InvalidOperationException("Failed to get access token.");
    }
}