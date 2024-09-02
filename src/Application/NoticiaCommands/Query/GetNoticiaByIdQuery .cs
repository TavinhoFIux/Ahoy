using Application.NoticiaCommands.Validations;
using Application.Utils;
using Domain.Entitys;
using FluentValidation.Results;

namespace Application.NoticiaCommands.Query
{
    public class GetNoticiaByIdQuery : Command<Noticia>
    {
        public int Id { get; set; }

        public GetNoticiaByIdQuery(int id)
        {
            Id = id;
        }

        public override ValidationResult Validate()
        {
            return new GetNoticiaByIdQueryValidator().Validate(this);
        }
    }
}
