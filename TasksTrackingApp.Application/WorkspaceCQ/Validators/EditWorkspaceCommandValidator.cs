using FluentValidation;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;

namespace TasksTrackingApp.Application.WorkspaceCQ.Validators
{
    public class EditWorkspaceCommandValidator : AbstractValidator<EditWorkspaceCommand>
    {
        public EditWorkspaceCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("O título não pode ser vazio");
            RuleFor(p => p.Status).NotNull().WithMessage("O status é obrigatório");
        }
    }
}
