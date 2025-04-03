using Appllication.Commom;
using AutoMapper;
using Domain.Interfaces.Repository;
using Domain.Mediators.Pokemon.Query;
using Domain.Model;
using MediatR;

namespace Appllication.Mediators.Pokemon.Query
{
    public class GetRandomPokemonQueryHandler(IPokemonRepository _repository, IMapper _mapper) : IRequestHandler<GetRandomPokemonQuery, List<Domain.Model.Pokemon>>
    {
        public async Task<List<Domain.Model.Pokemon>> Handle(GetRandomPokemonQuery request, CancellationToken cancellationToken)
        {
            var randomPokemons = await _repository.GetRandomAsync(cancellationToken);

            foreach (var pokemon in randomPokemons)
                await CommonMethods.GetBase64PokemonImageAsync(pokemon, cancellationToken);

            return _mapper.Map<List<Domain.Model.Pokemon>>(randomPokemons);
        }
    }
}
