using Domain.Model;
using MediatR;

namespace Domain.Mediators.PokemonMaster.Command
{
    public class InsertPokemonMasterCommand : IRequest<Response<Model.PokemonMaster>>
    {
        public Model.PokemonMaster PokemonMaster { get; set; } = null!;
    }
}
