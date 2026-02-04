namespace api.Models
{
    public class BinderDetailsDto
    {
        public int BinderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PokemonCardDto> Cards { get; set; }
        = new List<PokemonCardDto>();
        
    }
}
