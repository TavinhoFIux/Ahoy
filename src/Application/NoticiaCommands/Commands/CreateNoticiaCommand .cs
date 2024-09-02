using Application.NoticiaCommands.Validations;
using Application.Utils;
using FluentValidation.Results;

namespace Application.NoticiaCommands.Commands
{
    public class CreateNoticiaCommand : Command<int>
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public List<int> TagIds { get; set; }

        public override ValidationResult Validate()
        {
            return new CreateNoticiaCommandValidator().Validate(this);
        }
    }
}
