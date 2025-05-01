using GameStore.CleanArch.Backend.API.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Queries
{
    public class GetGameByIdQuery(int id) : IRequest<GameResponseModel?>
    {
        public int Id { get; set; } = id;
    }


}
