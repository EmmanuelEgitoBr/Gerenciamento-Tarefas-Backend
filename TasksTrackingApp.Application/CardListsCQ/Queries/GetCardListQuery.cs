using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.CardListsCQ.Queries
{
    public record GetCardListQuery : IRequest<ResponseBase<ListCardDto>>
    {
        public Guid Id { get; set; }
    }
}
