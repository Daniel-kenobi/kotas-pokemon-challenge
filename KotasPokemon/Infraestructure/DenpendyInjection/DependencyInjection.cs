using Domain.Mediators.PokemonMaster;
using Infraestructure.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.DenpendyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(x =>
            {
                x.AddProfile<MapperProfile>();
            });
            
            return serviceCollection;
        }
    }
}
