using System.Text.Json.Serialization;

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

            public List<PokemonAbilityWrapperDto> Abilities { get; set; } = new();

            public List<PokemonStatWrapperDto> Stats { get; set; } = new();
        }

        // TYPES
        public class PokemonTypeWrapperDto
        {
            public PokemonTypeDto Type { get; set; } = new();
        }

        public class PokemonTypeDto
        {
            public string Name { get; set; } = string.Empty;
        }

        // ABILITIES
        public class PokemonAbilityWrapperDto
        {
            public PokemonAbilityDto Ability { get; set; } = new();
        }

        public class PokemonAbilityDto
        {
            public string Name { get; set; } = string.Empty;
        }

        // STATS
        public class PokemonStatWrapperDto
        {
            [JsonPropertyName("base_stat")]
            public int BaseStat { get; set; }

            public PokemonStatDto Stat { get; set; } = new();
        }

        public class PokemonStatDto
        {
            public string Name { get; set; } = string.Empty;
        }
   
    }
