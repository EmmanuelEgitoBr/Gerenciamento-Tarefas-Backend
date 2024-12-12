using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.CardListsCQ.Commands;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardListsCQ.Handlers
{
    public class EditCardListCommandHandler : IRequestHandler<EditCardListCommand, ResponseBase<ListCardDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditCardListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ListCardDto>> Handle(EditCardListCommand request, CancellationToken cancellationToken)
        {
            var listCard = await _unitOfWork.ListCardRepository.GetAsync(x => x.Id ==  request.Id);

            if (listCard == null)
            {
                return new ResponseBase<ListCardDto>
                {
                    Title = "Lista de cards não encontrada",
                    HttpStatus = 404,
                    Value = null
                };
            }

            listCard.Title = request.Title!;
            listCard.Status = request.Status;

            _unitOfWork.ListCardRepository.Update(listCard);
            _unitOfWork.Commit();

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
