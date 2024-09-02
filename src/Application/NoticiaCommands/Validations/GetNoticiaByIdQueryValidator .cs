using Application.NoticiaCommands.Query;
using FluentValidation;

namespace Application.NoticiaCommands.Validations
{
    public class GetNoticiaByIdQueryValidator : AbstractValidator<GetNoticiaByIdQuery>
    {
        public GetNoticiaByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID da notícia deve ser maior que zero.");
        }
    }
}
