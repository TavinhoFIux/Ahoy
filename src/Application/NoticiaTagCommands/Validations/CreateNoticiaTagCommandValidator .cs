using Application.NoticiaTagCommands.Commands;
using FluentValidation;

namespace Application.NoticiaTagCommands.Validations
{
    public class CreateNoticiaTagCommandValidator : AbstractValidator<CreateNoticiaTagCommand>
    {
        public CreateNoticiaTagCommandValidator()
        {
            RuleFor(x => x.NoticiaId)
                .GreaterThan(0).WithMessage("O ID da notícia é inválido.");

            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage("O ID da tag é inválido.");
        }
    }
}
