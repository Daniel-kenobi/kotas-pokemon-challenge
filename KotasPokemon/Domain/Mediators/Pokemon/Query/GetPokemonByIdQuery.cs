using MediatR;

namespace Domain.Mediators.Pokemon.Query
{
    public class GetPokemonByIdQuery : IRequest<Domain.Model.Pokemon>
    {
        public int Id { get; set; }
    }
}
