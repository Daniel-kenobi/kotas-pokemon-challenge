using Domain.Model;
using MediatR;

namespace Domain.Mediators.Pokemon.Query
{
    public class GetRandomPokemonQuery : IRequest<List<Domain.Model.Pokemon>>
    {

    }
}
