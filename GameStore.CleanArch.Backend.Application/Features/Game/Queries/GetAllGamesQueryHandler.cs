using AutoMapper;
using GameStore.CleanArch.Backend.API.Models;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Queries
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<GameResponseModel>>
    {

        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;

        public GetAllGamesQueryHandler(IMapper mapper, IGameRepository gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }
        
        public async Task<IEnumerable<GameResponseModel>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GameResponseModel>>(games);
        }
    }
}
