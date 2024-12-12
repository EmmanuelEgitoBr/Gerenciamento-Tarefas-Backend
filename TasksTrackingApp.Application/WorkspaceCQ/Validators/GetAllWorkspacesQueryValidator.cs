using FluentValidation;
using TasksTrackingApp.Application.WorkspaceCQ.Queries;

namespace TasksTrackingApp.Application.WorkspaceCQ.Validators
{
    public class GetAllWorkspacesQueryValidator : AbstractValidator<GetAllWorkspacesQuery>
    {
        public GetAllWorkspacesQueryValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().WithMessage("O id do workspace não pode ser vazio");
        }
    }
}
