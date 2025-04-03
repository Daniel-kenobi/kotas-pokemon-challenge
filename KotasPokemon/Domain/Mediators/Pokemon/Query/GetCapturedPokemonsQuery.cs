using MediatR;

namespace Domain.Mediators.Pokemon.Query
{
    public class GetCapturedPokemonsQuery : IRequest<List<Domain.Model.Pokemon>>
    {

    }
}
