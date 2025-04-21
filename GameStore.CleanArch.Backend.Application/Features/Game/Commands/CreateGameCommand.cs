using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Commands
{
    public class CreateGameCommand : IRequest<OkResponseModel>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public decimal Price { get; set; }

        public CreateGameCommand(string title, string description, DateTime release, decimal price)
        {
            Title = title;
            Description = description;
            Release = release;
            Price = price;
        }
    }
}
