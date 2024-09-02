using Application.TagCommands.Commands;
using FluentValidation;

namespace Application.TagCommands.Validations
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(100).WithMessage("A descrição não pode exceder 100 caracteres.");
        }
    }
}
