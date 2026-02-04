using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class Binder
    {
        public int BinderId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<PokemonCard> PokemonCard { get; set; }
            = new List<PokemonCard>(); 
        public Binder(string name) // want the Binder class to always ahave a name 
        {
            Name = name;
        }
    }
}
