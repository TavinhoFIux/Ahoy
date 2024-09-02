using Application.UsuarioCommands.Commands;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;

namespace Application.UsuarioCommands.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario { Nome = request.Nome, Senha = request.Senha, Email = request.Email };
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync(cancellationToken);
            return usuario.Id;
        }
    }

}
