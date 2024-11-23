using App.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace App.Services;

public interface IAuthService
{
    Task<bool> CreateUserAsync(RegisterViewModel model);

    Task<User?> GetUserAsync(string id);

    Task<string> GetApiAccessTokenAsync();
}