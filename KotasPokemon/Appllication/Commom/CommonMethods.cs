namespace Appllication.Commom
{
    public static class CommonMethods
    {
        public async static Task GetBase64PokemonImageAsync(Domain.Entities.Pokemon pokemon, CancellationToken cancellationToken)
        {
            foreach (var variation in pokemon.Variations)
            {
                var spritePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "External", "Images", variation.Image);

                if (File.Exists(spritePath))
                {
                    var bytes = await File.ReadAllBytesAsync(spritePath, cancellationToken);
                    variation.ImageBase64 = Convert.ToBase64String(bytes);
                }
            }
        }
    }
}
