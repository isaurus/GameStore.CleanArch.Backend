using GameStore.CleanArch.Backend.Domain.Entities;
using GameStore.CleanArch.Backend.Domain.Models;

namespace GameStore.CleanArch.Backend.Domain.Contracts.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>   // IMPLEMENTADO POR IBASEREPOSITORY
    {
        Task<IEnumerable<Game?>> GetByTitleAsync(string title);
        Task<IEnumerable<Game?>> GetByReleaseYearAsync(int year);
    }
}
