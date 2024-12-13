using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.CardCQ.Commands
{
    public record CreateCardCommand : IRequest<ResponseBase<CardDto>>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid ListCardId { get; set; }
    }
}
