namespace api.Models
{
    public class PokemonCardUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Set { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public int BinderId { get; set; }
    }
}
