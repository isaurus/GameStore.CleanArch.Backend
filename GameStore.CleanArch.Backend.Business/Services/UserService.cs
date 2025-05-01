using GameStore.CleanArch.Backend.Application.Features.User.Commands;
using GameStore.CleanArch.Backend.Application.Features.User.Queries;
using GameStore.CleanArch.Backend.Domain.Contracts.Services;
using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Business.Services
{
    public class UserService : IUserService
    {

        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OkResponseModel> AddUserAsync(UserModel model)
        {
            var userCommand = new CreateUserCommand(model);
            
            return await _mediator.Send(userCommand, default(CancellationToken));
        }

        public async Task<OkResponseModel?> DeleteUserAsync(int id)
        {
            var userCommand = new DeleteUserCommand(id);

            return await _mediator.Send(userCommand, default(CancellationToken));
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync()
        {
            return await _mediator.Send(new GetAllUsersQuery(), default(CancellationToken));
        }

        public async Task<UserResponseModel?> GetUserByIdAsync(int id)
        {
            var userCommand = new GetUserByIdQuery(id);
            
            return await _mediator.Send(userCommand, default(CancellationToken));
        }

        public async Task<OkResponseModel?> UpdateUserAsync(int id, UserModel model)
        {
            var userCommand = new UpdateUserCommand(id, model);

            return await _mediator.Send(userCommand, default(CancellationToken));
        }
    }
}
