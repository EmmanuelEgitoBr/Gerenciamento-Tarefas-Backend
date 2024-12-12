using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.CardListsCQ.Queries
{
    public record GetCardListsQuery : IRequest<ResponseBase<List<ListCardDto>>>
    {
        public Guid Id { get; set; }
    }
}
