using Domain.Interfaces.Repository;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository.Pokemon
{
    public class PokemonRepository(ApplicationDbContext _context) : IPokemonRepository
    {
        public async Task<Domain.Entities.Pokemon> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Pokemons.AsNoTracking().Include(x => x.Variations).ThenInclude(y => y.Stats).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<Domain.Entities.Pokemon>> GetCapturedPokemonsAsync(CancellationToken cancellationToken = default)
        {
            return _context.Pokemons.AsNoTracking().Include(x => x.Variations).ThenInclude(y => y.Stats).Where(x => x.Captured).ToListAsync(cancellationToken);
        }

        public async Task<List<Domain.Entities.Pokemon>> GetRandomAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Pokemons.AsNoTracking().Include(x => x.Variations).ThenInclude(y => y.Stats).OrderBy(x => EF.Functions.Random()).Take(10).ToListAsync(cancellationToken);
        }

        public async Task MarkPokemonAsCapturedAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Pokemons.FirstAsync(x => x.Id == id);

            entity.Captured = true;

            _context.Pokemons.Attach(entity);
            _context.Entry(entity).Property(x => x.Captured).IsModified = true;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
