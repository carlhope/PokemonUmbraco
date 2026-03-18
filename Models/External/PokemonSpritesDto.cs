using System.Text.Json.Serialization;

namespace PokemonUmbraco.Models.External
{
    public class PokemonSpritesDto
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; } = string.Empty;
    }
}
