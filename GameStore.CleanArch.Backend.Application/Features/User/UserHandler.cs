using AutoMapper;
using GameStore.CleanArch.Backend.Application.Features.User.Commands;
using GameStore.CleanArch.Backend.Application.Features.User.Queries;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Models;
using MediatR;

namespace GameStore.CleanArch.Backend.Application.Features.User
{
    public class UserHandler(IMapper mapper, IUserRepository userRepository) :
        IRequestHandler<GetAllUsersQuery>, IEnumerable<UserResponseModel>,
        IRequestHandler<GetUserByIdQuery>, UserResponseModel?>,
        IRequestHandler<CreateUserCommand>, OkResponseModel>,
        IRequestHandler<UpdateUserCommand>, OkResponseModel?>,
        IRequestHandler<DeleteUserCommand>, OkResponseModel?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<IEnumerable<UserResponseModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            _mapper.Map<IEnumerable<UserResponseModel>>(users);
        }

        public Task Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
