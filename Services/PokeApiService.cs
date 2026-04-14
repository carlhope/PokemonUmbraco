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
        public async Task<List<PokemonDto>> GetPokemonListAsync(int count)
        {
            // 1. Call the list endpoint safely
            var response = await _client.GetAsync($"pokemon?limit={count}");

            if (!response.IsSuccessStatusCode)
                return new List<PokemonDto>();

            var list = await response.Content.ReadFromJsonAsync<PokemonListDto>();

            if (list?.Results == null || list.Results.Count == 0)
                return new List<PokemonDto>();

            // 2. Fetch each Pokémon
            var tasks = list.Results
                .Select(item => GetPokemonAsync(item.Name))
                .ToList();

            var results = await Task.WhenAll(tasks);

            // 3. Filter out nulls
            return results.Where(p => p != null).ToList();
        }
    }
}
