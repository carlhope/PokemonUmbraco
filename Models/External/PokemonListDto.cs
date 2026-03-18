namespace PokemonUmbraco.Models.External
{
    public class PokemonListDto
    {
        public int Count { get; set; }
        public List<PokemonListItemDto> Results { get; set; } = new();
    }

    public class PokemonListItemDto
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
