using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Application.CardCQ.Commands
{
    public record EditCardCommand : IRequest<ResponseBase<CardDto>>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public StatusCardEnum Status { get; set; }
    }
}
