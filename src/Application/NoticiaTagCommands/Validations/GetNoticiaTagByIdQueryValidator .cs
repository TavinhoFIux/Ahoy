using Application.NoticiaTagCommands.Query;
using FluentValidation;

namespace Application.NoticiaTagCommands.Validations
{
    public class GetNoticiaTagByIdQueryValidator : AbstractValidator<GetNoticiaTagByIdQuery>
    {
        public GetNoticiaTagByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID da NoticiaTag deve ser maior que zero.");
        }
    }
}
