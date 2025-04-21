using AutoMapper;
using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Application.Features.Game.Commands;
using GameStore.CleanArch.Backend.Application.Features.Game.Queries;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game
{
    public class GameHandler :
        IRequestHandler<GetAllGamesQuery, IEnumerable<GameResponseModel>>,
        IRequestHandler<CreateGameCommand, OkResponseModel>
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

        public async Task<OkResponseModel> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Game>(request);
            //abrir llaves sino
            return await _gameRepository.AddAsync(entity);
        }
    }
}
