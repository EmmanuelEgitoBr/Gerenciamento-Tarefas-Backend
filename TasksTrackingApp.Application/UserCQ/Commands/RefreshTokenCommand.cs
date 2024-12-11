using MediatR;
using System.Text.Json.Serialization;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.UserCQ.Commands
{
    public record RefreshTokenCommand : IRequest<ResponseBase<UserDto>>
    {
        public string? Username { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }
    }
}
