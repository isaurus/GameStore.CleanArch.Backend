using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Domain.Models;

namespace GameStore.CleanArch.Backend.Domain.Contracts.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameResponseModel>> GetAllGamesAsync();
        Task<GameResponseModel?> GetGameByIdAsync(int id);
        Task<OkResponseModel> AddGameAsync(GameModel model);
        Task<OkResponseModel?> UpdateGameAsync(int id, GameModel model);
        Task<OkResponseModel?> DeleteGameAsync(int id, GameModel model);



        Task<IEnumerable<GameResponseModel>> GetGameByTitleAsync(string title);
        Task<IEnumerable<GameResponseModel>> GetGameByReleaseYearAsync(int year);
    }
}
