using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.User.Commands
{
    public class DeleteUserCommand(int id) : IRequest<OkResponseModel?>
    {
        public int Id { get; set; } = id;
    }
}
