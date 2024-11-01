using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.UserCQ.Commands
{
    public record CreateUserCommand : IRequest<ResponseBase<UserDto>>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
