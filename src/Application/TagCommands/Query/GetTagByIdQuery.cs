using Application.TagCommands.Validations;
using Application.Utils;
using Domain.Entitys;
using FluentValidation.Results;
using MediatR;

namespace Application.TagCommands.Query
{
    public class GetTagByIdQuery : Command<Tag>
    {
        public int Id { get; set; }

        public GetTagByIdQuery(int id)
        {
            Id = id;
        }

        public override ValidationResult Validate()
        {
            return new GetTagByIdQueryValidator().Validate(this);
        }
    }
}
