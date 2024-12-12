using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Application.Utils;
using TasksTrackingApp.Application.WorkspaceCQ.Queries;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Application.WorkspaceCQ.Handlers
{
    public class GetAllWorkspacesQueryHandler : IRequestHandler<GetAllWorkspacesQuery, ResponseBase<PaginatedList<WorkspaceDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWorkspacesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<PaginatedList<WorkspaceDto>>> Handle(GetAllWorkspacesQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                return new ResponseBase<PaginatedList<WorkspaceDto>>
                {
                    Title = "Usuário não encontrado",
                    HttpStatus = 404,
                    Value = null
                };
            }

            var workspaces = await _unitOfWork.WorkspaceRepository.GetAllWorkspacesByUserIdAsync(user.Id);
            var items = _mapper.Map<List<WorkspaceDto>>(workspaces);

            var paginatedItems = new PaginatedList<WorkspaceDto>(items, request.PageIndex, request.PageSize);

            return new ResponseBase<PaginatedList<WorkspaceDto>>
            {
                Title = "Workspaces encontrados",
                HttpStatus = 201,
                Value = paginatedItems
            };
        }
    }
}
