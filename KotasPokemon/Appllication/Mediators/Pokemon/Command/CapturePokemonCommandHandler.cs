using Domain.Interfaces.Repository;
using Domain.Mediators.Pokemon.Commmand;
using MediatR;

namespace Appllication.Mediators.Pokemon.Command
{
    public class CapturePokemonCommandHandler(IPokemonRepository _repository) : IRequestHandler<CapturePokemonCommand>
    {
        public async Task Handle(CapturePokemonCommand request, CancellationToken cancellationToken)
        {
            if (request is null || request.Id <= 0)
                throw new Exception("Pokemon Id can't be null.");

            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
                throw new Exception("Pokemon doesn't exist on database.");

            await _repository.MarkPokemonAsCapturedAsync(request.Id, cancellationToken);
        }
    }
}
