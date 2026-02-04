namespace api.Models
{
    public class BinderDto
    {  
        public int BinderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CardCount
        {
            get
            {
                return PokemonCard.Count;
            }
        }
        public ICollection<PokemonCardDto> PokemonCard { get; set; }
        = new List<PokemonCardDto>();
    }
}
