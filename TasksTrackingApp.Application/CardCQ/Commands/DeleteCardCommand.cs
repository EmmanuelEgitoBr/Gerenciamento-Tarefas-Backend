using MediatR;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.CardCQ.Commands
{
    public record DeleteCardCommand : IRequest<ResponseBase<Guid>>
    {
        public Guid Id { get; set; }
    }
}
