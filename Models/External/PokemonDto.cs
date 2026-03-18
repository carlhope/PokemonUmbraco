namespace PokemonUmbraco.Models.External
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }

        public PokemonSpritesDto Sprites { get; set; } = new();

        public List<PokemonTypeWrapperDto> Types { get; set; } = new();
    }

    public class PokemonTypeWrapperDto
    {
        public PokemonTypeDto Type { get; set; } = new();
    }

    public class PokemonTypeDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
