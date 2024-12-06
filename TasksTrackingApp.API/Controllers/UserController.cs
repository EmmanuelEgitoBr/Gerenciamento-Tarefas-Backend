using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.UserCQ.Commands;

namespace TasksTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint para criação de usuário
        /// </summary>
        /// <remarks>
        /// Exemplo de request
        /// ```
        /// POST api/User/Create-User
        /// </remarks>
        /// <returns></returns>
        [HttpPost("Create-User")]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
