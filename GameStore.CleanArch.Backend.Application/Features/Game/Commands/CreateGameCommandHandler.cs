using AutoMapper;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Commands
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, OkResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;

        public CreateGameCommandHandler(IMapper mapper, IGameRepository repository)
        {
            _mapper = mapper;
            _gameRepository = repository;
        }

        public async Task<OkResponseModel> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Game>(request);
            await _gameRepository.AddAsync(entity);
            return new OkResponseModel
            {
                Id = entity.Id,
                Message = "Juego creado con éxito."
            };
            
        }
    }
}
