using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Domain.Abstractions;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.UserCQ.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResponseBase<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration; 

        public LoginUserCommandHandler(IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IAuthService authService,
                                        IConfiguration configuration)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
            _configuration = configuration;
        }

        public async Task<ResponseBase<UserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == request.Email);

            if (user is null) 
            {
                return new ResponseBase<UserDto>
                {
                    Title = "Usuário não encontrado!",
                    HttpStatus = 404,
                    Value = null
                };
            }

            var hashPassword = _authService.HashingPassword(request.Password!);

            if (hashPassword != user.PasswordHash)
            {
                return new ResponseBase<UserDto>
                {
                    Title = "A senha informada está incorreta!",
                    HttpStatus = 404,
                    Value = null
                };
            }

            user.RefreshToken = _authService.GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenExpirationTime"]!.ToString(), out int refreshTime);
            user.RefreshTokenExpirationTime = DateTime.Now.AddHours(refreshTime);

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _authService.GenerateJwtToken(user.Email, user.Username);

            return new ResponseBase<UserDto>
            {
                Title = "Login feito com sucesso",
                HttpStatus = 200,
                Value = userDto
            };
        }
    }
}
