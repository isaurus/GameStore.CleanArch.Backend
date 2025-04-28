using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Commands
{
    public class DeleteGameCommand(int id) : IRequest<OkResponseModel?>
    {
        public int Id { get; set; } = id;
    }
}
