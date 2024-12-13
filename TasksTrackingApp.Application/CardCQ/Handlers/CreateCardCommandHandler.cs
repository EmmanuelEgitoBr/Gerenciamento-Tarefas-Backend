using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.CardCQ.Commands;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardCQ.Handlers
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, ResponseBase<CardDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<CardDto>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card
            {
                Title = request.Title!,
                Description = request.Description!,
                Deadline = request.Deadline,
                ListCardId = request.ListCardId
            };

            var result = await _unitOfWork.CardRepository.CreateAsync(card);

            if (result is null)
            {
                return new ResponseBase<CardDto>
                {
                    Title = "Erro ao criar card!",
                    Value = null
                };
            }

            var cardDto = _mapper.Map<CardDto>(result);

            return new ResponseBase<CardDto>
            {
                Title = "Card criado com sucesso",
                HttpStatus = 201,
                Value = cardDto
            };
        }
    }
}
