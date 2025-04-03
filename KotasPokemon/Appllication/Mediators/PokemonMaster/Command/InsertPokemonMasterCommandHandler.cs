using AutoMapper;
using Domain.Extensions;
using Domain.Interfaces.Repository;
using Domain.Mediators.PokemonMaster.Command;
using Domain.Model;
using MediatR;

namespace Appllication.Mediators.PokemonMaster.Command
{
    public class InsertPokemonMasterCommandHandler(IMapper _mapper, IRepositoryBase<Domain.Entities.PokemonMaster> _pokemonMasterRepository) : IRequestHandler<InsertPokemonMasterCommand, Response<Domain.Model.PokemonMaster>>
    {
        public async Task<Response<Domain.Model.PokemonMaster>> Handle(InsertPokemonMasterCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<Domain.Model.PokemonMaster>();

            if (request.PokemonMaster is null)
                throw new Exception("Pokemon Master is null.");

            if (!CpfValidator.IsValid(request.PokemonMaster.Cpf))
                throw new Exception("Invalid CPF.");

            var entityMapped = _mapper.Map<Domain.Entities.PokemonMaster>(request.PokemonMaster);

            if (!string.IsNullOrEmpty(entityMapped.Cpf))
            {
                var foundEntity = await _pokemonMasterRepository.GetOneAsync(entityMapped, cancellationToken);

                if (foundEntity is not null)
                    throw new Exception("Pokemon Master already exists on database.");
            }

            var createdEntity = await _pokemonMasterRepository.CreateAsync(entityMapped, cancellationToken);
            response.Result = _mapper.Map<Domain.Model.PokemonMaster>(createdEntity);

            return response;
        }
    }
}
