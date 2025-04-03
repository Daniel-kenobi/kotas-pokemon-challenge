using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infraestructure.Data
{
    public static class SeedDatabase
    {
        public async static Task SeedAsync(CancellationToken cancellationToken = default)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            string dbPath = Path.Join(path, "pokemon.db");

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseSqlite($"Data Source={dbPath}")
                 .Options;

            using var context = new ApplicationDbContext(options);
            await context.Database.MigrateAsync(cancellationToken);

            var transaction = context.Database.BeginTransaction();

            var seedLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "External", "SeedsSchema", "pokedex.json");
            var jsonData = File.ReadAllText(seedLocation);

            if (!context.Pokemons.Any())
            {
                 seedLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "External", "SeedsSchema", "pokedex.json");
                 jsonData = File.ReadAllText(seedLocation);

                var pokemons = JsonSerializer.Deserialize<List<Domain.Entities.Pokemon>>(jsonData, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if (pokemons != null)
                {
                    foreach (var pokemon in pokemons)
                    {
                        if (pokemon.Variations != null)
                        {
                            foreach (var variation in pokemon.Variations)
                            {
                                variation.Pokemon = pokemon; 
                                variation.PokemonId = pokemon.Id;

                                if (variation.Stats != null)
                                {
                                    variation.Stats.Variation = variation;
                                    variation.Stats.VariationId = variation.Id;
                                }
                            }
                        }
                    }

                    await context.Pokemons.AddRangeAsync(pokemons, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }

            transaction.Commit();
        }
    }
}
