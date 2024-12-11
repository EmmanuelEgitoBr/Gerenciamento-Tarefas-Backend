using MediatR;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Application.WorkspaceCQ.Handlers
{
    public class DeleteWorkspaceCommandHandler : IRequestHandler<DeleteWorkspaceCommand, ResponseBase<DeleteWorkspaceCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWorkspaceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseBase<DeleteWorkspaceCommand>> Handle(DeleteWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _unitOfWork.WorkspaceRepository.GetAsync(w => w.Id == request.Id);

            if (workspace == null)
            {
                return new ResponseBase<DeleteWorkspaceCommand>
                {
                    Title = "Workspace não encontrado",
                    HttpStatus = 404,
                    Value = null
                };
            }

            await _unitOfWork.WorkspaceRepository.Delete(workspace);
            _unitOfWork.Commit();

            return new ResponseBase<DeleteWorkspaceCommand>
            {
                Title = "Workspace excluído com sucesso",
                HttpStatus = 204,
                Value = request
            };
        }
    }
}
