using Application.TagCommands.Validations;
using Application.Utils;
using FluentValidation.Results;
using MediatR;


namespace Application.TagCommands.Commands
{
    public class UpdateTagCommand : Command<Unit>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public override ValidationResult Validate()
        {
            return new UpdateTagCommandValidator().Validate(this);
        }
    }
}
