using Microsoft.AspNetCore.Identity.Data;
using PokemonUmbraco.Models.Auth;

namespace PokemonUmbraco.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginRequest request);
        Task LogoutAsync();
        Task<bool> RegisterAsync(RegistrationModel request);
    }
}
