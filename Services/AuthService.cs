using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.Data;
using PokemonUmbraco.Models.Auth;
using PokemonUmbraco.Services.Interfaces;

namespace PokemonUmbraco.Services
{
    public class AuthService: IAuthService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _nav;

        public AuthService(HttpClient http, NavigationManager nav)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://localhost:44380");
            _nav = nav;

        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("/auth/login", request);
          return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> RegisterAsync(RegistrationModel request)
        {
            RegisterRequest registerRequest = new RegisterRequest
            {
                Email = request.Email,
                Password = request.Password
            };
            var response = await _http.PostAsJsonAsync("/auth/register", registerRequest);
            return response.StatusCode == System.Net.HttpStatusCode.OK;

        }

        public async Task LogoutAsync()
        {
            await _http.PostAsync("/auth/logout", null);
        }
    }

}
