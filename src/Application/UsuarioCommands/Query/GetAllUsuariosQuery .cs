using Domain.Entitys;
using MediatR;

namespace Application.UsuarioCommands.Query
{
    public class GetAllUsuariosQuery : IRequest<List<Usuario>>
    {
    }
}
