using GameStore.CleanArch.Backend.API.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Queries
{
    public class GetAllGamesQuery : IRequest<IEnumerable<GameResponseModel>>
    {
    }
}
