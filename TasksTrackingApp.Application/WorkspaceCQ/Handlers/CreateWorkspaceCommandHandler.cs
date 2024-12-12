using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.WorkspaceCQ.Handlers
{
    public class CreateWorkspaceCommandHandler : IRequestHandler<CreateWorkspaceCommand, ResponseBase<WorkspaceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWorkspaceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<WorkspaceDto>> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Id == request.UserId);

            if (user == null)
            {
                return new ResponseBase<WorkspaceDto>
                {
                    Title = "Usuário não encontrado",
                    HttpStatus = 400,
                    Value = null
                };
            }

            var workspace = new Workspace()
            {
                UserId = user.Id,
                Title = request.Title!
            };

            await _unitOfWork.WorkspaceRepository.CreateAsync(workspace);
            _unitOfWork.Commit();

            return new ResponseBase<WorkspaceDto>
            {
                Title = "Workspace criado com êxito",
                HttpStatus = 200,
                Value = _mapper.Map<WorkspaceDto>(workspace)
            };
        }
    }
}
