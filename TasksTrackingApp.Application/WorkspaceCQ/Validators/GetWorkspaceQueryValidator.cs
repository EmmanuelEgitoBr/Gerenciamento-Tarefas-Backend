using FluentValidation;
using TasksTrackingApp.Application.WorkspaceCQ.Queries;

namespace TasksTrackingApp.Application.WorkspaceCQ.Validators
{
    public class GetWorkspaceQueryValidator : AbstractValidator<GetWorkspaceQuery>
    {
        public GetWorkspaceQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("O id do workspace não pode ser vazio");
        }
    }
}
