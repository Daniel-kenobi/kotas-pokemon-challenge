using AutoMapper;
using Domain.Interfaces.Repository;
using Domain.Mediators.PokemonMaster.Query;
using MediatR;

namespace Appllication.Mediators.PokemonMaster.Query
{
    public class GetAllPokemonMastersQueryHandler(IMapper _mapper, IRepositoryBase<Domain.Entities.PokemonMaster> _pokemonMasterRepository) : IRequestHandler<GetAllPokemonMastersQuery, List<Domain.Model.PokemonMaster>>
    {
        public async Task<List<Domain.Model.PokemonMaster>> Handle(GetAllPokemonMastersQuery request, CancellationToken cancellationToken)
        {
            var pokemonMasters = await _pokemonMasterRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<Domain.Model.PokemonMaster>>(pokemonMasters);
        }
    }
}
