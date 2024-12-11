using FluentValidation;
using TasksTrackingApp.Application.UserCQ.Commands;

namespace TasksTrackingApp.Application.UserCQ.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("O campo email não pode ser vazio")
                .EmailAddress().WithMessage("O campo Email está no formato incorreto");
            RuleFor(p => p.Password).MinimumLength(4).WithMessage("A senha precisa ter, no mínimo, 4 caracteres");
        }
    }
}
