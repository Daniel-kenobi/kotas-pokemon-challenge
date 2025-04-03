using MediatR;

namespace Domain.Mediators.PokemonMaster.Query
{
    public class GetAllPokemonMastersQuery : IRequest<List<Domain.Model.PokemonMaster>>
    {

    }
}
