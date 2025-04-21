using GameStore.CleanArch.Backend.Domain.Entities;

namespace GameStore.CleanArch.Backend.Domain.Contracts.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<IEnumerable<Game?>> GetByTitleAsync(string title);
        Task<IEnumerable<Game?>> GetByReleaseYearAsync(int year);
    }
}
