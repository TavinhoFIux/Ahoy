using Application.UsuarioCommands.Query;
using FluentValidation;

namespace Application.UsuarioCommands.Validations
{
    public class GetUsuarioByIdQueryValidator : AbstractValidator<GetUsuarioByIdQuery>
    {
        public GetUsuarioByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero.");
        }
    }
}
