using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasksTrackingApp.Application.CardListsCQ.Commands;
using TasksTrackingApp.Application.CardListsCQ.Queries;

namespace TasksTrackingApp.API.Controllers
{
    public static class CardListsController
    {
        public static void CardListsRoutes(this WebApplication app)
        {
            var group = app.MapGroup("cardlists").WithTags("CardLists");
            group.MapGet("get-cardlists/{workspaceId:guid}", GetCardListsByWorkspaceId);
            group.MapGet("get-cardlist/{cardListId:guid}", GetCardListByListId);
            group.MapPut("update-cardlist", EditCardList);
            group.MapPost("create-cardlist", CreateCardList);
            group.MapDelete("delete-cardlist/{cardListId:guid}", DeleteCardList);
        }

        /// <summary>
        /// Endpoint que retorna todas as listas de cards pelo Id do workspace
        /// </summary>
        /// <remarks>
        /// GET api/cardlists/get-cardlists
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> GetCardListsByWorkspaceId([FromServices] IMediator _mediator,
                                                       Guid workspaceId)
        {
            var result = await _mediator.Send(new GetCardListsQuery { Id = workspaceId });

            return Results.Ok(result.Value);
        }

        /// <summary>
        /// Endpoint que retorna uma lista de cards pelo seu Id
        /// </summary>
        /// <remarks>
        /// GET api/cardlists/get-cardlist
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> GetCardListByListId([FromServices] IMediator _mediator,
                                                       Guid cardListId)
        {
            var result = await _mediator.Send(new GetCardListQuery { Id = cardListId });

            if (result.Value is null) return Results.BadRequest(result.Title);

            return Results.Ok(result.Value);
        }

        /// <summary>
        /// Endpoint que edita uma lista de cards pelo seu Id
        /// </summary>
        /// <remarks>
        /// PUT api/cardlists/update-cardlist
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> EditCardList([FromServices] IMediator _mediator,
                                                        EditCardListCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Value is null) return Results.BadRequest(result.Title);

            return Results.Ok(result.Value);
        }

        /// <summary>
        /// Endpoint que cria uma lista de cards
        /// </summary>
        /// <remarks>
        /// POST api/cardlists/create-cardlist
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> CreateCardList([FromServices] IMediator _mediator,
                                                          CreateCardListCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Value is null) return Results.BadRequest(result.Title);

            return Results.Ok(result.Value);
        }

        /// <summary>
        /// Endpoint que apaga uma lista de cards
        /// </summary>
        /// <remarks>
        /// DELETE api/cardlists/delete-cardlist
        /// </remarks>
        /// <returns></returns>
        public static async Task<IResult> DeleteCardList([FromServices] IMediator _mediator,
                                                          Guid cardListId)
        {
            var result = await _mediator.Send(new DeleteCardListCommand { Id = cardListId });

            if (result.Value == Guid.Empty) return Results.BadRequest(result.Title);

            return Results.Ok(result.Value);
        }
    }
}
