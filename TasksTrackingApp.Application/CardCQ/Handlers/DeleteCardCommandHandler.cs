using AutoMapper;
using MediatR;
using TasksTrackingApp.Application.CardCQ.Commands;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardCQ.Handlers
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseBase<Guid>> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetAsync(c => c.Id == request.Id);

            if (card == null)
            {
                return new ResponseBase<Guid>
                {
                    Title = "Card não encontrado",
                    HttpStatus = 404,
                    Value = Guid.Empty
                };
            }

            await _unitOfWork.CardRepository.Delete(card);
            _unitOfWork.Commit();

            return new ResponseBase<Guid>
            {
                Title = "Card excluído com sucesso!",
                HttpStatus = 200,
                Value = request.Id
            };
        }
    }
}
