using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Application.CardListsCQ.Commands
{
    public record EditCardListCommand : IRequest<ResponseBase<ListCardDto>>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public StatusItemEnum Status { get; set; }
    }
}
