using MediatR;

namespace Application.UsuarioCommands.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
