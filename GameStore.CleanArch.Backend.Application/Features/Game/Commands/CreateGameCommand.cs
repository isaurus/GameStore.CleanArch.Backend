using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Commands
{
    // Este es el 'Request Object'
    public class CreateGameCommand : IRequest<OkResponseModel> // IRequest<T> es la 'Response'
    {
        public GameModel Model { get; set; }
        public CreateGameCommand(GameModel model)
        {
            Model = model;
        }

        /*
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Release { get; set; }
        public decimal Price { get; set; }
        */
    }
}
