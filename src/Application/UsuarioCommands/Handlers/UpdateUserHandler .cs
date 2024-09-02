using Application.UsuarioCommands.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.UsuarioCommands.Handlers
{

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuario.FindAsync(request.Id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            usuario.Nome = request.Nome;
            usuario.Senha = request.Senha;
            usuario.Email = request.Email;

            _context.Update(usuario);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
