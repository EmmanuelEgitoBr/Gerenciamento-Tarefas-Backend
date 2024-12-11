using Azure.Core;
using k8s.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.UserCQ.Commands;

namespace TasksTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
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
        public async Task<ActionResult<ResponseBase<UserDto>>> CreateUser(CreateUserCommand command)
        {
            var request = await _mediator.Send(command);

            if(request.Value is not null)
            {
                var cookieOptionsToken = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddHours(5)
                };

                _ = int.TryParse(_configuration["JWT:RefreshTokenExpirationTime"]!.ToString(), out int refreshTime);

                var cookieOptionsRefreshToken = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddHours(refreshTime)
                };

                Response.Cookies.Append("jwt", request.Value.Token.ToString(), cookieOptionsToken);
                Response.Cookies.Append("refreshToken", request.Value.RefreshToken.ToString(), cookieOptionsRefreshToken);

                return Ok(request);
            }

            return BadRequest(request);
        }

        /// <summary>
        /// Endpoint para login de usuário
        /// </summary>
        /// <remarks>
        /// POST api/User/login
        /// </remarks>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<ResponseBase<UserDto>>> Login(LoginUserCommand command)
        {
            var request = await _mediator.Send(command);

            if (request.Value is not null)
            {
                var cookieOptionsToken = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddHours(5)
                };

                _ = int.TryParse(_configuration["JWT:RefreshTokenExpirationTime"]!.ToString(), out int refreshTime);

                var cookieOptionsRefreshToken = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddHours(refreshTime)
                };

                Response.Cookies.Append("jwt", request.Value.Token.ToString(), cookieOptionsToken);
                Response.Cookies.Append("refreshToken", request.Value.RefreshToken.ToString(), cookieOptionsRefreshToken);

                return Ok(request);
            }

            return BadRequest(request);
        }

        /// <summary>
        /// Endpoint para geração do Refresh Token
        /// </summary>
        /// <remarks>
        /// POST api/User/refresh-token
        /// </remarks>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        public async Task<ActionResult<ResponseBase<UserDto>>> RefreshToken(RefreshTokenCommand command)
        {
            var request = await _mediator.Send(new RefreshTokenCommand
            {
                Username = command.Username,
                RefreshToken = Request.Cookies["refreshToken"]
            });

            if (request.Value is null) return BadRequest(request);

            return Ok(request);
        }
    }
}
