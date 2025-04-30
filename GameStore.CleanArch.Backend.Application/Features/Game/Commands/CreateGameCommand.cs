using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Commands
{
    public class CreateGameCommand(GameModel model) : IRequest<OkResponseModel>
    {
        public GameModel Model { get; set; } = model;
    }
}
