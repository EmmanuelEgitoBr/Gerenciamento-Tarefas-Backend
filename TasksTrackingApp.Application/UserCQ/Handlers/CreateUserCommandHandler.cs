using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Domain.Abstractions;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Application.UserCQ.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseBase<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IAuthService authService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<ResponseBase<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkExistingUser = _authService.CheckUniqueUserAndEmail(request.Email, request.Username);

            if(!checkExistingUser) 
                return new ResponseBase<UserDto>()
                {
                    Title = "Erro ao criar usuário. Email ou nome de usuário existentes!",
                    HttpStatus = 404,
                    Value = null
                };

            var user = _mapper.Map<User>(request);
            user.RefreshToken = _authService.GenerateRefreshToken();
            user.PasswordHash = _authService.HashingPassword(request.Password);

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _authService.GenerateJwtToken(user.Email, user.Username);

            await _unitOfWork.UserRepository.CreateAsync(user);
            _unitOfWork.Commit();

            return new ResponseBase<UserDto>()
            {
                Title = "Usuário criado com sucesso",
                HttpStatus = 201,
                Value = userDto
            };
        }
    }
}
