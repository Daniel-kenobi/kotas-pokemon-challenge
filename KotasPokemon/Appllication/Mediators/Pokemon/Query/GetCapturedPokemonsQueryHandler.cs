using Appllication.Commom;
using AutoMapper;
using Domain.Interfaces.Repository;
using Domain.Mediators.Pokemon.Query;
using MediatR;

namespace Appllication.Mediators.Pokemon.Query
{
    public class GetCapturedPokemonsQueryHandler(IPokemonRepository _repository, IMapper _mapper) : IRequestHandler<GetCapturedPokemonsQuery, List<Domain.Model.Pokemon>>
    {
        public async Task<List<Domain.Model.Pokemon>> Handle(GetCapturedPokemonsQuery request, CancellationToken cancellationToken)
        {
            var pokemons = await _repository.GetCapturedPokemonsAsync(cancellationToken);

            foreach (var pokemon in pokemons)
                await CommonMethods.GetBase64PokemonImageAsync(pokemon, cancellationToken);

            return _mapper.Map<List<Domain.Model.Pokemon>>(pokemons);
        }
    }
}
