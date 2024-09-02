using Application.Utils;
using Domain.Entitys;
using MediatR;

namespace Application.NoticiaCommands.Query
{
    public class GetAllNoticiasQuery : Command<IEnumerable<Noticia>>
    {
    }
}

