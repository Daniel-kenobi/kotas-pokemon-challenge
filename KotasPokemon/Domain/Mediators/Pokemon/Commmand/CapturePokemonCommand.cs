using MediatR;

namespace Domain.Mediators.Pokemon.Commmand
{
    public class CapturePokemonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
