using Application.NoticiaCommands.Commands;
using FluentValidation;

namespace Application.NoticiaCommands.Validations
{
    public class CreateNoticiaCommandValidator : AbstractValidator<CreateNoticiaCommand>
    {
        public CreateNoticiaCommandValidator()
        {
            RuleFor(n => n.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(200).WithMessage("O título não pode exceder 200 caracteres.");

            RuleFor(n => n.Texto)
                .NotEmpty().WithMessage("O texto é obrigatório.");

            RuleForEach(n => n.TagIds).GreaterThan(0).WithMessage("Tag inválida.");
        }
    }
}
