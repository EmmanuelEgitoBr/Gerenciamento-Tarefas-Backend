using FluentValidation;
using TasksTrackingApp.Application.CardCQ.Commands;

namespace TasksTrackingApp.Application.CardCQ.Validators
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            
        }
    }
}
