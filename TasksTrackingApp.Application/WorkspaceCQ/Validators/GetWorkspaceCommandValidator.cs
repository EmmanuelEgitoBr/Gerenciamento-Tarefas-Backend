using FluentValidation;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.WorkspaceCQ.Commands;

namespace TasksTrackingApp.Application.WorkspaceCQ.Validators
{
    public class GetWorkspaceCommandValidator : AbstractValidator<GetWorkspaceCommand>
    {
        public GetWorkspaceCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("O id do workspace não pode ser vazio");
        }
    }
}
