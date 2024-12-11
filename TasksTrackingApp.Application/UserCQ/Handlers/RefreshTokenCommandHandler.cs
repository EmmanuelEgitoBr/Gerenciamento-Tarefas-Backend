using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Domain.Abstractions;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Application.UserCQ.Handlers
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ResponseBase<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommandHandler(IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IAuthService authService,
                                        IConfiguration configuration)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
            _configuration = configuration;
        }

        public async Task<ResponseBase<UserDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Username == request.Username);

            if (user is null 
                || user.RefreshToken != request.RefreshToken 
                || user.RefreshTokenExpirationTime < DateTime.Now)
            {
                return new ResponseBase<UserDto>
                {
                    Title = "Usuário/Token inválido!",
                    HttpStatus = 400,
                    Value = null
                };
            }

            user.RefreshToken = _authService.GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenExpirationTime"]!.ToString(), out int refreshTime);
            user.RefreshTokenExpirationTime = DateTime.Now.AddHours(refreshTime);

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _authService.GenerateJwtToken(user.Email, user.Username);

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();

            return new ResponseBase<UserDto>
            {
                Title = "Refresh feito com sucesso",
                HttpStatus = 200,
                Value = userDto
            };
        }
    }
}
