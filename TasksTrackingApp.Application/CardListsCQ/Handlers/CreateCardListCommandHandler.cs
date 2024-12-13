using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.CardListsCQ.Commands;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardListsCQ.Handlers
{
    public class CreateCardListCommandHandler : IRequestHandler<CreateCardListCommand, ResponseBase<ListCardDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCardListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ListCardDto>> Handle(CreateCardListCommand request, CancellationToken cancellationToken)
        {
            var listCard = new ListCard
            {
                Title = request.Title!,
                WorkspaceId = request.WorkspaceId!
            };

            var result = await _unitOfWork.ListCardRepository.CreateAsync(listCard);
            var listCardDto = _mapper.Map<ListCardDto>(result);


            return new ResponseBase<ListCardDto>
            {
                Title = "Lista de cards criada com sucesso",
                HttpStatus = 201,
                Value = listCardDto
            };
        }
    }
}
