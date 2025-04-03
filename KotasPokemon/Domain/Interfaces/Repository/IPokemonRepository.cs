namespace Domain.Interfaces.Repository
{
    public interface IPokemonRepository 
    {
        Task<Domain.Entities.Pokemon> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Domain.Entities.Pokemon>> GetCapturedPokemonsAsync(CancellationToken cancellationToken = default);
        Task<List<Domain.Entities.Pokemon>> GetRandomAsync(CancellationToken cancellationToken = default);
        Task MarkPokemonAsCapturedAsync(int id, CancellationToken cancellationToken = default);
    }
}
