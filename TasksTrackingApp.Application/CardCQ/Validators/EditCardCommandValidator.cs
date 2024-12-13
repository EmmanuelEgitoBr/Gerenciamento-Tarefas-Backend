using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksTrackingApp.Application.CardCQ.Commands;

namespace TasksTrackingApp.Application.CardCQ.Validators
{
    public class EditCardCommandValidator : AbstractValidator<EditCardCommand>
    {
        public EditCardCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("O Id não pode ser vazio");
            RuleFor(p => p.Title).NotEmpty().WithMessage("O título não pode ser vazio");
            RuleFor(p => p.Description).NotEmpty().WithMessage("A descrição não pode ser vazio");
            RuleFor(p => p.Deadline).NotEmpty().WithMessage("A data de expiração é obrigatória");
        }
    }
}
