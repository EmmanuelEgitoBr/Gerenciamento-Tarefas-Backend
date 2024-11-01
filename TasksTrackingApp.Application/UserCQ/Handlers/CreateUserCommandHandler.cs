using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Infrastructure.Persistence;

namespace TasksTrackingApp.Application.UserCQ.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseBase<UserDto>>
    {
        private readonly TasksDbContext _tasksDbContext;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(TasksDbContext tasksDbContext, IMapper mapper)
        {
            _tasksDbContext = tasksDbContext;
            _mapper = mapper;
        }

        public async Task<ResponseBase<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            _tasksDbContext.Users.Add(user);
            _tasksDbContext.SaveChanges();

            return new ResponseBase<UserDto>()
            {
                ResponseInfo = null,
                Value = _mapper.Map<UserDto>(user)
            };
        }
    }
}
