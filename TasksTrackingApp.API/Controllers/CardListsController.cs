using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasksTrackingApp.Application.CardListsCQ.Queries;

namespace TasksTrackingApp.API.Controllers
{
    public static class CardListsController
    {
        public static void CardListsRoutes(this WebApplication app)
        {
            var group = app.MapGroup("cardlists").WithTags("CardLists");
            group.MapGet("get-cardlists/{workspaceId}", GetCardListsByWorkspaceId);
        }

        /// <summary>
        /// Endpoint que retorna todas as listas de cards pelo Id do workspace
        /// </summary>
        /// <remarks>
        /// POST api/cardlists/get-cardlists
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> GetCardListsByWorkspaceId([FromServices] IMediator _mediator,
                                                       Guid workspaceId)
        {
            var result = await _mediator.Send(new GetCardListsQuery { Id = workspaceId });

            if (result.Value is null) return Results.BadRequest(result.Title);

            return Results.Ok(result);
        }
    }
}
