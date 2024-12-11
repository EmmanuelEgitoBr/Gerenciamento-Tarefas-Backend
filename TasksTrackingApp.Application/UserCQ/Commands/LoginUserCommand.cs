using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.UserCQ.Commands
{
    public record LoginUserCommand : IRequest<ResponseBase<UserDto>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
