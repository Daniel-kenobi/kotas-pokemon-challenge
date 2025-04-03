using Appllication.Commom;
using AutoMapper;
using Domain.Interfaces.Repository;
using Domain.Mediators.Pokemon.Query;
using Domain.Model;
using MediatR;

namespace Appllication.Mediators.Pokemon.Query
{
    public class GetPokemonByIdQueryHandler(IPokemonRepository _repository, IMapper _mapper) : IRequestHandler<GetPokemonByIdQuery, Domain.Model.Pokemon>
    {
        public async Task<Domain.Model.Pokemon> Handle(GetPokemonByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null || request.Id <= 0)
                throw new Exception("Id can't be null.");

            var pokemon = await _repository.GetByIdAsync(request.Id, cancellationToken);
            await CommonMethods.GetBase64PokemonImageAsync(pokemon, cancellationToken);

            return _mapper.Map<Domain.Model.Pokemon>(pokemon);
        }
    }
}
