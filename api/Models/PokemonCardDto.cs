namespace api.Models
{
    public class PokemonCardDto
    {
        public int PokemonCardId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Set { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
}
