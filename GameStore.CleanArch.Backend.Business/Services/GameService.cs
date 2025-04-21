using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Application.Features.Game.Commands;
using GameStore.CleanArch.Backend.Application.Features.Game.Queries;
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
            var gameCommand = new CreateGameCommand(model.Title, model.Description, model.Release, model.Price);

            return await _mediator.Send(gameCommand);
        }

        public Task DeleteGameAsync(GameModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GameResponseModel>> GetAllGamesAsync()
        {
            return await _mediator.Send(new GetAllGamesQuery());
        }

        public Task<GameResponseModel?> GetGameByIdAsync(int id)
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
