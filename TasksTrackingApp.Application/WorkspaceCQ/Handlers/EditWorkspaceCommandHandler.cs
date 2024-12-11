using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Application.WorkspaceCQ.Handlers
{
    public class EditWorkspaceCommandHandler : IRequestHandler<EditWorkspaceCommand, ResponseBase<WorkspaceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditWorkspaceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<WorkspaceDto>> Handle(EditWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _unitOfWork.WorkspaceRepository.GetAsync(w => w.Id == request.Id);

            if (workspace == null)
            {
                return new ResponseBase<WorkspaceDto> {
                    Title = "Workspace não encontrado",
                    HttpStatus = 404,
                    Value = null
                };
            }

            workspace.Title = request.Title!;
            workspace.Status = request.Status;

            _unitOfWork.WorkspaceRepository.Update(workspace);
            _unitOfWork.Commit();

            var workspaceDto = _mapper.Map<WorkspaceDto>(workspace);

            return new ResponseBase<WorkspaceDto>
            {
                Title = "Workspace atualizado com sucesso!",
                HttpStatus = 201,
                Value = workspaceDto
            };
        }
    }
}
