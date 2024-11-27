using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.IRepositories;

namespace TasksTrackingApp.Application.UserCQ.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseBase<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseBase<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _userRepository.CreateAsync(user);

            return new ResponseBase<UserDto>()
            {
                ResponseInfo = null,
                Value = _mapper.Map<UserDto>(user)
            };
        }
    }
}
