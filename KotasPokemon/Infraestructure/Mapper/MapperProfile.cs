using AutoMapper;

namespace Infraestructure.MapperProfiles
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Entities.PokemonMaster, Domain.Model.PokemonMaster>();
            CreateMap<Domain.Model.PokemonMaster, Domain.Entities.PokemonMaster>();

            CreateMap<Domain.Model.Pokemon, Domain.Entities.Pokemon>();
            CreateMap<Domain.Entities.Pokemon, Domain.Model.Pokemon>();

            CreateMap<Domain.Model.Stats, Domain.Entities.Stats>();
            CreateMap<Domain.Entities.Stats, Domain.Model.Stats>();

            CreateMap<Domain.Model.Variation, Domain.Entities.Variation>();
            CreateMap<Domain.Entities.Variation, Domain.Model.Variation>();
        }
    }
}
