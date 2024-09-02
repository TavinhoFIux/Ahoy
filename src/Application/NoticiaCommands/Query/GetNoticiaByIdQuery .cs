using Domain.Entitys;
using MediatR;

namespace Application.NoticiaCommands.Query
{
    public class GetNoticiaByIdQuery : IRequest<Noticia>
    {
        public int Id { get; set; }

        public GetNoticiaByIdQuery(int id)
        {
            Id = id;
        }
    }
}
