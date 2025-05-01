using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponseModel>>
    {
    }
}
