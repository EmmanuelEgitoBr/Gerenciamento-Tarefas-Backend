using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;

namespace TasksTrackingApp.Application.WorkspaceCQ.Queries
{
    public class GetWorkspaceQuery : IRequest<ResponseBase<WorkspaceDto>>
    {
        public Guid Id { get; set; }
    }
}
