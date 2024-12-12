using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.CardListsCQ.Queries;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardListsCQ.Handlers
{
    public class GetCardListsQueryHandler : IRequestHandler<GetCardListsQuery, ResponseBase<List<ListCardDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCardListsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<List<ListCardDto>>> Handle(GetCardListsQuery request, CancellationToken cancellationToken)
        {
            var listCards = await _unitOfWork.ListCardRepository.GetAllCardListByWorkspaceId(request.Id);

            var listDto = _mapper.Map<List<ListCardDto>>(listCards);

            return new ResponseBase<List<ListCardDto>>
            {
                Title = "Workspace encontrado com sucesso",
                HttpStatus = 200,
                Value = listDto
            };
        }
    }
}
