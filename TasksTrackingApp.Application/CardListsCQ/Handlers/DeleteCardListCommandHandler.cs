using MediatR;
using TasksTrackingApp.Application.CardListsCQ.Commands;
using TasksTrackingApp.Application.Response;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;

namespace TasksTrackingApp.Application.CardListsCQ.Handlers
{
    public class DeleteCardListCommandHandler : IRequestHandler<DeleteCardListCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCardListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseBase<Guid>> Handle(DeleteCardListCommand request, CancellationToken cancellationToken)
        {
            var listCard = await _unitOfWork.ListCardRepository.GetAsync(x => x.Id == request.Id);

            if (listCard == null)
            {
                return new ResponseBase<Guid>
                {
                    Title = "Lista de cards não encontrada",
                    HttpStatus = 404,
                    Value = Guid.Empty
                };
            }

            var cards = _unitOfWork.CardRepository.GetAllAsync().Result.Where(x => x.ListCardId == request.Id).ToList();
            await _unitOfWork.CardRepository.DeleteRange(cards);
            await _unitOfWork.ListCardRepository.Delete(listCard);

            _unitOfWork.Commit();

            return new ResponseBase<Guid>
            {
                Title = "Lista de cards excluída com sucesso",
                HttpStatus = 204,
                Value = request.Id
            };
        }
    }
}
