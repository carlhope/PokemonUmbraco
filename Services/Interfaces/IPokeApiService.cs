using PokemonUmbraco.Models.External;

namespace PokemonUmbraco.Services.Interfaces
{
    public interface IPokeApiService
    {
        Task<PokemonDto?> GetPokemonAsync(string name);
    }
}
