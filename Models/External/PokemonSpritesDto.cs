using System.Text.Json.Serialization;

namespace PokemonUmbraco.Models.External
{
    public class PokemonSpritesDto
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; } = string.Empty;

        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; } = string.Empty;

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; } = string.Empty;

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; } = string.Empty;

        public PokemonOtherSpritesDto Other { get; set; } = new();
    }


    public class PokemonOtherSpritesDto
    {
        [JsonPropertyName("official-artwork")]
        public PokemonOfficialArtworkDto OfficialArtwork { get; set; } = new();
    }

    public class PokemonOfficialArtworkDto
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; } = string.Empty;
    }
}
