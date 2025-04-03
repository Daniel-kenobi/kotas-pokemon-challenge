using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<PokemonMaster> PokemonMasters { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Stats> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                 .HasMany(p => p.Variations)
                 .WithOne(v => v.Pokemon)
                 .HasForeignKey(v => v.PokemonId);

            modelBuilder.Entity<Variation>()
                .Ignore(x => x.ImageBase64)
                .HasOne(v => v.Stats)
                .WithOne(s => s.Variation)
                .HasForeignKey<Stats>(s => s.VariationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
