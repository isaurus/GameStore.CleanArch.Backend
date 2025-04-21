using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Domain.Models;

namespace GameStore.CleanArch.Backend.Domain.Contracts.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameResponseModel>> GetAllGamesAsync();
        Task<GameModel?> GetGameByIdAsync(int id);
        Task<OkResponseModel> AddGameAsync(GameModel model);
        Task UpdateGameAsync(GameModel model);
        Task DeleteGameAsync(GameModel model);



        Task<IEnumerable<GameModel>> GetGameByTitleAsync(string title);
        Task<IEnumerable<GameModel>> GetGameByReleaseYearAsync(int year);
    }
}
