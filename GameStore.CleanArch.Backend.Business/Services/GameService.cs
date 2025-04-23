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

            return await _mediator.Send(gameCommand, default(CancellationToken));
        }

        public async Task<OkResponseModel?> DeleteGameAsync(int id)    // ¡IMPLEMENTAR!
        {
            var gameCommand = new DeleteGameCommand(id);

            return await _mediator.Send(gameCommand, default(CancellationToken));
        }

        public async Task<IEnumerable<GameResponseModel>> GetAllGamesAsync()
        {
            return await _mediator.Send(new GetAllGamesQuery(), default(CancellationToken));
        }

        public async Task<GameResponseModel?> GetGameByIdAsync(int id)
        {
            return await _mediator.Send(new GetGameByIdQuery(id), default(CancellationToken));
        }

        public Task<IEnumerable<GameResponseModel>> GetGameByReleaseYearAsync(int year)     // ¡IMPLEMENTAR!
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameResponseModel>> GetGameByTitleAsync(string title)       // ¡IMPLEMENTAR!
        {
            throw new NotImplementedException();
        }

        public async Task<OkResponseModel?> UpdateGameAsync(int id, GameModel model)      // !VERIFICAR!
        {
            var gameCommand = new UpdateGameCommand(id, model.Title, model.Description, model.Release, model.Price);

            return await _mediator.Send(gameCommand, default(CancellationToken));
        }
    }
}
