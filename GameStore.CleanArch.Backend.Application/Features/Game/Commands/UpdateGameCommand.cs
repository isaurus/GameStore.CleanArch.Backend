using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Commands
{
    public class UpdateGameCommand(int id, GameModel model) : IRequest<OkResponseModel?>
    {
        public int Id { get; set; } = id;
        public GameModel Model { get; set; } = model;
    }
}
