using System.ComponentModel.DataAnnotations.Schema;
// don't forget to update the database 
// Add-Migration MigrationName
// Update-Database
namespace api.Entities
{
    public class PokemonCard
    {
        public int PokemonCardId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Set { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        [ForeignKey("BinderId")]
        public Binder? Binder { get; set; }
        public int BinderId { get; set; }
        public PokemonCard(string name)
        {
            Name = name;
        }
        public int SortNumber { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
