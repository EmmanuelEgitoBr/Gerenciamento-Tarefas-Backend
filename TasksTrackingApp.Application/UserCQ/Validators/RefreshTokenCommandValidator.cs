using FluentValidation;
using TasksTrackingApp.Application.UserCQ.Commands;

namespace TasksTrackingApp.Application.UserCQ.Validators
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(u =>  u.Username).NotEmpty().WithMessage("O campo username não pode ser vazio!");
        }
    }
}
