using Application.NoticiaCommands.Commands;
using FluentValidation;

namespace Application.NoticiaCommands.Validations
{
    public class EditNoticiaCommandValidator : AbstractValidator<UpdateNoticiaCommand>
    {
        public EditNoticiaCommandValidator()
        {
            RuleFor(n => n.Titulo)
                .MaximumLength(200).WithMessage("O título não pode exceder 200 caracteres.");
            RuleForEach(n => n.TagIds).GreaterThan(0).WithMessage("Tag inválida.");
            RuleFor(n => n.TagIds)
                .NotEmpty().WithMessage("A lista de Tags não pode estar vazia.");
        }
    }
}
