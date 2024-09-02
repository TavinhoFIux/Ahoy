using Application.TagCommands.Query;
using FluentValidation;

namespace Application.TagCommands.Validations
{
    public class GetTagByIdQueryValidator : AbstractValidator<GetTagByIdQuery>
    {
        public GetTagByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero.");
        }
    }
}
