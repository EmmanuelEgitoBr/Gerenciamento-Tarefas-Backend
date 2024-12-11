using FluentValidation;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;

namespace TasksTrackingApp.Application.WorkspaceCQ.Validators
{
    public class DeleteWorkspaceCommandValidator : AbstractValidator<DeleteWorkspaceCommand>
    {
        public DeleteWorkspaceCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("O id do workspace não pode ser vazio");

        }
    }
}
