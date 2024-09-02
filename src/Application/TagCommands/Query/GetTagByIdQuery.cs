using Domain.Entitys;
using MediatR;

namespace Application.TagCommands.Query
{
    public class GetTagByIdQuery : IRequest<Tag>
    {
        public int Id { get; set; }

        public GetTagByIdQuery(int id)
        {
            Id = id;
        }
    }
}
