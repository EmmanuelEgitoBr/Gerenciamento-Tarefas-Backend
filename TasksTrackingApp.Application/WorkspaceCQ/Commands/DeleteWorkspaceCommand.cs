using MediatR;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.WorkspaceCQ.Commands
{
    public record DeleteWorkspaceCommand : IRequest<ResponseBase<DeleteWorkspaceCommand>>
    {
        public Guid Id { get; set; }
    }
}
