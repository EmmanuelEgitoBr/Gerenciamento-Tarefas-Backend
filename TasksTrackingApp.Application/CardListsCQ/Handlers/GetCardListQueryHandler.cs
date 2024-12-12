using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.CardListsCQ.Queries;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardListsCQ.Handlers
{
    public class GetCardListQueryHandler : IRequestHandler<GetCardListQuery, ResponseBase<ListCardDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCardListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ListCardDto>> Handle(GetCardListQuery request, CancellationToken cancellationToken)
        {
            var listCard = await _unitOfWork.ListCardRepository.GetAsync(l => l.Id == request.Id);

            if (listCard is null)
            {
                return new ResponseBase<ListCardDto>
                {
                    Title = "Lista de cards não encontrada",
                    HttpStatus = 404,
                    Value = null
                };
            }

            var cards = await _unitOfWork.CardRepository.GetAllCardsByListId(listCard.Id);

            if (cards is not null)
            {
                listCard.Cards = cards;
            }

            var listCardsDto = _mapper.Map<ListCardDto>(listCard);

            return new ResponseBase<ListCardDto>
            {
                Title = "Lista de cards encontrada com sucesso",
                HttpStatus = 200,
                Value = listCardsDto
            };
        }
    }
}
