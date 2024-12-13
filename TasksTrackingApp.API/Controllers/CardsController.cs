using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasksTrackingApp.Application.CardCQ.Commands;
using TasksTrackingApp.Application.CardListsCQ.Commands;
using TasksTrackingApp.Application.DTOs;

namespace TasksTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Endpoint que cria um card
        /// </summary>
        /// <remarks>
        /// POST api/cards/create-card
        /// </remarks>
        /// <returns></returns>
        [HttpPost("create-card")]
        public async Task<ActionResult<CardDto>> CreateCard([FromBody] CreateCardCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Value is null) return BadRequest(result.Title);

            return Ok(result.Value);
        }

        /// <summary>
        /// Endpoint que edita um card
        /// </summary>
        /// <remarks>
        /// PUT api/cards/update-card
        /// </remarks>
        /// <returns></returns>
        [HttpPut("update-card")]
        public async Task<ActionResult<CardDto>> EditCard([FromBody] EditCardCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Value is null) return BadRequest(result.Title);

            return Ok(result.Value);
        }

        /// <summary>
        /// Endpoint que apaga um card
        /// </summary>
        /// <remarks>
        /// DELETE api/cards/delete-card
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("delete-card/{cardId:guid}")]
        public async Task<ActionResult<Guid>> DeleteCard(Guid cardId)
        {
            var result = await _mediator.Send(new DeleteCardCommand { Id = cardId });

            if (result.Value == Guid.Empty) return BadRequest(result.Title);

            return Ok(result.Value);
        }

    }
}
