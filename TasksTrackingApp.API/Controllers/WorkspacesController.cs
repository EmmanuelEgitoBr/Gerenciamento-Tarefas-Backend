using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;

namespace TasksTrackingApp.API.Controllers
{
    public static class WorkspacesController
    {
        public static void WorkspacesRoutes(this WebApplication app)
        {
            var group = app.MapGroup("workspaces").WithTags("Workspaces");

            //group.MapGet("get-workspace", GetWorkspace);
            //group.MapGet("get-workspaces", GetAllWorkspaces);
            group.MapPost("create-workspace", CreateWorkspace);
            group.MapPut("update-workspace", EditWorkspace);
            group.MapDelete("delete-workspace/{workspaceId}", DeleteWorkspace);
        }

        //DELEGATES

        /*
        public static async Task<IResult> GetWorkspace([FromServices] IMediator _mediator)
        {
            
        }
        public static async Task<IResult> GetAllWorkspaces([FromServices] IMediator _mediator)
        {

        }
        */

        /// <summary>
        /// Endpoint para criação de workspace
        /// </summary>
        /// <remarks>
        /// POST api/workspaces/create-workspace
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> CreateWorkspace([FromServices] IMediator _mediator,
                                                            [FromBody] CreateWorkspaceCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Value is null) return Results.BadRequest(result.Title);

            return Results.Ok(result);
        }

        /// <summary>
        /// Endpoint para edição de workspace
        /// </summary>
        /// <remarks>
        /// POST api/workspaces/update-workspace
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> EditWorkspace([FromServices] IMediator _mediator,
                                                            [FromBody] EditWorkspaceCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Value is null) return Results.BadRequest(result.Title);

            return Results.Ok(result);
        }

        /// <summary>
        /// Endpoint para exclusão de workspace
        /// </summary>
        /// <remarks>
        /// POST api/workspaces/delete-workspace
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> DeleteWorkspace([FromServices] IMediator _mediator,
                                                            Guid workspaceId)
        {
            var result = await _mediator.Send(new DeleteWorkspaceCommand { Id = workspaceId});

            if (result.Value is null) return Results.BadRequest(result.Title);

            return Results.Ok(result);
        }
    }
}
