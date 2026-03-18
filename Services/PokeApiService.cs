using PokemonUmbraco.Models.External;
using PokemonUmbraco.Services.Interfaces;

namespace PokemonUmbraco.Services
{
    public class PokeApiService : IPokeApiService
    {
        private readonly HttpClient _client;

        public PokeApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<PokemonDto?> GetPokemonAsync(string name)
        {
            var response = await _client.GetAsync($"pokemon/{name.ToLower()}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<PokemonDto>();
        }
    }
}
