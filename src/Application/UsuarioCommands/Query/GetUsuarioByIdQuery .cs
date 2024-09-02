using Domain.Entitys;
using MediatR;

namespace Application.UsuarioCommands.Query
{
    public class GetUsuarioByIdQuery : IRequest<Usuario>
    {
        public int Id { get; set; }

        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }
    }
}
