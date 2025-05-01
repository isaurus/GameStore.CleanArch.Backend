using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.User.Queries
{
    public class GetUserByIdQuery(int id) : IRequest<UserResponseModel?>
    {
        public int Id { get; set; } = id;
    }
}
