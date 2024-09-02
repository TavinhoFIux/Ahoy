using Application.UsuarioCommands.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.UsuarioCommands.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuario.FindAsync(request.Id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
