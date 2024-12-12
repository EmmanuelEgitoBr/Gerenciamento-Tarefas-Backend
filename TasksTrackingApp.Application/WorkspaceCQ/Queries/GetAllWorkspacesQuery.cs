using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.Utils;

namespace TasksTrackingApp.Application.WorkspaceCQ.Queries
{
    public record GetAllWorkspacesQuery : QueryBase, IRequest<ResponseBase<PaginatedList<WorkspaceDto>>>
    {
        public Guid UserId { get; set; }
    }
}
