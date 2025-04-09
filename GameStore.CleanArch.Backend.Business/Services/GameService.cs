using AutoMapper;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Contracts.Services;
using GameStore.CleanArch.Backend.Domain.Models;

namespace GameStore.CleanArch.Backend.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddGameAsync(GameModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameAsync(GameModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GameModel>> GetAllGamesAsync()    // VA CON EL MEDIATOR!!!!
        {
            var games = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GameModel>>(games);
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
