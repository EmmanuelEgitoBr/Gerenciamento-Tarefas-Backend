using FluentValidation;
using TasksTrackingApp.Application.UserCQ.Commands;

namespace TasksTrackingApp.Application.UserCQ.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("O campo email não pode ser vazio")
                .EmailAddress().WithMessage("O campo Email está no formato incorreto");
            RuleFor(p => p.Username).MinimumLength(1).WithMessage("O campo username não pode ser vazio");
        }
    }
}
