using Domain.Entitys;
using MediatR;

namespace Application.TagCommands.Query
{
    public class GetAllTagsQuery : IRequest<List<Tag>>
    {
    }
}
