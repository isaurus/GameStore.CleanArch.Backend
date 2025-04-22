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
    public class GameHandler :
        IRequestHandler<GetAllGamesQuery, IEnumerable<GameResponseModel>>,
        IRequestHandler<GetGameByIdQuery, GameResponseModel?>,
        IRequestHandler<CreateGameCommand, OkResponseModel>,
        IRequestHandler<UpdateGameCommand, OkResponseModel?>
    {

        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;

        public GameHandler(IMapper mapper, IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

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
            var game = _mapper.Map<Domain.Entities.Game>(request);
            await _gameRepository.AddAsync(game);

            return new OkResponseModel 
            {              
                Id = game.Id,
                Message = "Juego creado con éxito."
            };
        }

        public async Task<OkResponseModel?> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Domain.Entities.Game>(request);
            await _gameRepository.UpdateAsync(request.Id, game);

            return new OkResponseModel
            {
                Id = game.Id,
                Message = "Juego actualizado con éxito."
            };
        }
    }
}
