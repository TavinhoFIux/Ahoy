using MediatR;

namespace Application.UsuarioCommands.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
