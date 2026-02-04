using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.DbContexts
{
    public class PokemonBinderContext : DbContext
    {
        public DbSet<Binder> Binders { get; set; }
        public DbSet<PokemonCard> PokemonCards { get; set; }
        public PokemonBinderContext(DbContextOptions<PokemonBinderContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Binder>()
                .HasData(
                new Binder("Obtained")
                {
                    BinderId = 1
                },
                new Binder("Wishlist")
                {
                    BinderId = 2
                });
            modelBuilder.Entity<PokemonCard>()
                .HasData(
                new PokemonCard("Sylveon GX")
                {
                    PokemonCardId = 1,
                    BinderId = 2,
                    Set = "Hidden Fates",
                    Number = "SV76/SV94"
                },
                new PokemonCard("N's Zorua")
                {
                    PokemonCardId = 2,
                    BinderId = 1,
                    Set = "Journey Together",
                    Number = "SVP189"
                },
                new PokemonCard("Yamper on Bed")
                {
                    PokemonCardId = 3,
                    BinderId = 1,
                    Set = "Phantasmal Flames",
                    Number = "099/094"
                }
                );
            
            base.OnModelCreating(modelBuilder); // provide data for seeding the database 
        }
    }
}
