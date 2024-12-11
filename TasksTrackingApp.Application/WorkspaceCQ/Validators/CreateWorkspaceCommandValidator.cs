using FluentValidation;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;

namespace TasksTrackingApp.Application.WorkspaceCQ.Validators
{
    public class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
    {
        public CreateWorkspaceCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("O título não pode ser vazio");
        }
    }
}
