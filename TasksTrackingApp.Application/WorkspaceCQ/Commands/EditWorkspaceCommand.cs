using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Application.WorkspaceCQ.Commands
{
    public record EditWorkspaceCommand : IRequest<ResponseBase<WorkspaceDto>>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public StatusItemEnum Status { get; set; }
    }
}
