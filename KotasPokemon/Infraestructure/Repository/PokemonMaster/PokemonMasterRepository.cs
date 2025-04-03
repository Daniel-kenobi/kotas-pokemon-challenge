using Domain.Interfaces.Repository;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository.PokemonMaster
{
    public class PokemonMasterRepository(ApplicationDbContext _context) : IRepositoryBase<Domain.Entities.PokemonMaster>
    {
        public async Task<Domain.Entities.PokemonMaster> CreateAsync(Domain.Entities.PokemonMaster entity, CancellationToken cancellationToken = default)
        {
            await _context.PokemonMasters.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(Domain.Entities.PokemonMaster entity, CancellationToken cancellationToken = default)
        {
            var existentEntity = await _context.PokemonMasters.FirstOrDefaultAsync(x => x.Id == entity.Id && !x.Deleted, cancellationToken);

            if (existentEntity is null)
                throw new Exception("Pokemon Master doesn't exist.");

            existentEntity.Deleted = true;

            _context.PokemonMasters.Update(existentEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<List<Domain.Entities.PokemonMaster>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.PokemonMasters.Where(x => !x.Deleted).ToListAsync(cancellationToken);
        }

        public async Task<Domain.Entities.PokemonMaster> GetOneAsync(Domain.Entities.PokemonMaster entity, CancellationToken cancellationToken = default)
        {
            return await _context.PokemonMasters.FirstOrDefaultAsync(x => x.Id == entity.Id || x.Cpf == entity.Cpf && !x.Deleted, cancellationToken);
        }

        public async Task<Domain.Entities.PokemonMaster> UpdateAsync(Domain.Entities.PokemonMaster entity, CancellationToken cancellationToken = default)
        {
            var existentEntity = await _context.PokemonMasters.FirstOrDefaultAsync(x => x.Id == entity.Id && !x.Deleted, cancellationToken) ?? throw new Exception("Pokemon doesn't exists.");

            _context.PokemonMasters.Update(existentEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return existentEntity;
        }
    }
}
