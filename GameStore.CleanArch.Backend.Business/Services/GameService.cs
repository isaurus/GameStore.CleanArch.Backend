using GameStore.CleanArch.Backend.Application.Features.Game.Commands;
using GameStore.CleanArch.Backend.Domain.Contracts.Services;
using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IMediator _mediator;

        public GameService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OkResponseModel> AddGameAsync(GameModel model)
        {
            var result = await _mediator.Send(new CreateGameCommand(model));
            return result;
        }

        public Task DeleteGameAsync(GameModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GameModel>> GetAllGamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GameModel?> GetGameByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameModel>> GetGameByReleaseYearAsync(int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameModel>> GetGameByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGameAsync(GameModel model)
        {
            throw new NotImplementedException();
        }
    }
}
