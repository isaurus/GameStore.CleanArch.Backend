using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Commands
{
    public class UpdateGameCommand : IRequest<OkResponseModel?>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Release { get; set; }
        public decimal Price { get; set; }

        public UpdateGameCommand(int id, string title, string description, DateOnly release, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Release = release;
            Price = price;
        }
    }
}
