using FluentValidation;
using TasksTrackingApp.Application.CardListsCQ.Commands;

namespace TasksTrackingApp.Application.CardListsCQ.Validators
{
    public class CreateCardListCommandValidator : AbstractValidator<CreateCardListCommand>
    {
        public CreateCardListCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("O título não pode ser vazio");
            RuleFor(p => p.WorkspaceId).NotEmpty().WithMessage("O id do workspace não pode ser vazio");
        }
    }
}
