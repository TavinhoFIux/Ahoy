using Domain.Entitys;
using MediatR;

namespace Application.NoticiaCommands.Query
{
    public class GetAllNoticiasQuery : IRequest<IEnumerable<Noticia>>
    {
    }
}

