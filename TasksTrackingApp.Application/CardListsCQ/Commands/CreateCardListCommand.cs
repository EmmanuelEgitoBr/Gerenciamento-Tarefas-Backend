using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Application.CardListsCQ.Commands
{
    public record CreateCardListCommand : IRequest<ResponseBase<ListCardDto>>
    {
        public string? Title { get; set; }
        public Guid WorkspaceId { get; set; }
    }
}
