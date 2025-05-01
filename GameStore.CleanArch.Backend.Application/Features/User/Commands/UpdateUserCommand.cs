using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.User.Commands
{
    public class UpdateUserCommand(int id, UserModel model) : IRequest<OkResponseModel?>
    {
        public int Id { get; set; } = id;
        public UserModel Model { get; set; } = model;
    }
}
