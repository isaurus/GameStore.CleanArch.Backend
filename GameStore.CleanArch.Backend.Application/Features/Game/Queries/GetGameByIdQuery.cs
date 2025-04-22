using GameStore.CleanArch.Backend.API.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Queries
{
    public class GetGameByIdQuery : IRequest<GameResponseModel?>
    {
        public int Id{ get; set; }

        public GetGameByIdQuery(int id)
        {
            Id = id;
        }
    }

    
}
