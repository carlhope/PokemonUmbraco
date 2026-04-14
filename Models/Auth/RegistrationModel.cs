using System.ComponentModel.DataAnnotations;

namespace PokemonUmbraco.Models.Auth
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
