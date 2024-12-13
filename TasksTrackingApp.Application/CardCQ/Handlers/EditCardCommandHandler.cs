using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.CardCQ.Commands;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardCQ.Handlers
{
    public class EditCardCommandHandler : IRequestHandler<EditCardCommand, ResponseBase<CardDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<CardDto>> Handle(EditCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetAsync(c => c.Id == request.Id);

            if (card == null)
            {
                return new ResponseBase<CardDto>
                {
                    Title = "Card não encontrado",
                    HttpStatus = 404,
                    Value = null
                };
            }

            card.Title = request.Title!;
            card.Description = request.Description!;
            card.Deadline = request.Deadline!;

            var cardDto = _mapper.Map<CardDto>(card);

            return new ResponseBase<CardDto>
            {
                Title = "Card criado com sucesso",
                HttpStatus = 201,
                Value = cardDto
            };
        }
    }
}
