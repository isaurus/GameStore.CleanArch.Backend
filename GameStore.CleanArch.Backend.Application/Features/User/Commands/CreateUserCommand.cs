using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.User.Commands
{
    public class CreateUserCommand(UserModel model) : IRequest<OkResponseModel>
    {
        public UserModel Model { get; set; } = model;
    }
}
