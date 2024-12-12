using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.WorkspaceCQ.Commands
{
    public record GetWorkspaceCommand : IRequest<ResponseBase<WorkspaceDto>>
    {
        public Guid Id { get; set; }
    }
}
