using MediatR;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.CardListsCQ.Commands
{
    public record DeleteCardListCommand : IRequest<ResponseBase<Guid>>
    {
        public Guid Id { get; set; }
    }
}
