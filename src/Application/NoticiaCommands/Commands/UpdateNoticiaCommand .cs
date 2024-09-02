using Application.NoticiaCommands.Validations;
using Application.Utils;
using FluentValidation.Results;
using MediatR;

namespace Application.NoticiaCommands.Commands
{
    public class UpdateNoticiaCommand : Command<Unit>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public List<int> TagIds { get; set; }

        public override ValidationResult Validate()
        {
            return new EditNoticiaCommandValidator().Validate(this);
        }
    }
}
