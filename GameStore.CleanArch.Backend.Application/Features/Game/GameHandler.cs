using AutoMapper;
using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Application.Features.Game.Commands;
using GameStore.CleanArch.Backend.Application.Features.Game.Queries;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Entities;
using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game
{
    public class GameHandler(IMapper mapper, IGameRepository gameRepository) :
        IRequestHandler<GetAllGamesQuery, IEnumerable<GameResponseModel>>,
        IRequestHandler<GetGameByIdQuery, GameResponseModel?>,
        IRequestHandler<CreateGameCommand, OkResponseModel>,
        IRequestHandler<UpdateGameCommand, OkResponseModel?>,
        IRequestHandler<DeleteGameCommand, OkResponseModel?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGameRepository _gameRepository = gameRepository;

        public async Task<IEnumerable<GameResponseModel>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GameResponseModel>>(games);
        }

        public async Task<GameResponseModel?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GameResponseModel>(game);
        }

        public async Task<OkResponseModel> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Domain.Entities.Game>(request.Model);
            await _gameRepository.AddAsync(game);

            return new OkResponseModel 
            {              
                Id = game.Id,
                Message = "Juego creado con éxito."
            };
        }

        public async Task<OkResponseModel?> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {

            var existingGame = await _gameRepository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException($"Juego con id {request.Id} no se encuentra"); 

            _mapper.Map(request.Model, existingGame);

            await _gameRepository.UpdateAsync(request.Id, existingGame);

            return new OkResponseModel
            {
                Id = request.Id,
                Message = "Juego actualizado con éxito."
            };
        }

        public async Task<OkResponseModel?> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            await _gameRepository.DeleteAsync(request.Id);

            return new OkResponseModel
            {
                Id = null,
                Message = "Juego borrado con éxito."
            };
        }
    }
}
