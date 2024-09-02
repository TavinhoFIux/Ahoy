using Application.TagCommands.Validations;
using Application.Utils;
using FluentValidation.Results;

namespace Application.TagCommands.Commands
{
    public class CreateTagCommand : Command<int>
    {
        public string Descricao { get; set; }

        public override ValidationResult Validate()
        {
            return new CreateTagCommandValidator().Validate(this);
        }
    }
}
