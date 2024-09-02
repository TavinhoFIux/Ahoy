using Application.UsuarioCommands.Query;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;

namespace Application.UsuarioCommands.Handlers
{
    public class GetUsuarioByIdHandler : IRequestHandler<GetUsuarioByIdQuery, Usuario>
    {
        private readonly ApplicationDbContext _context;

        public GetUsuarioByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuario.FindAsync(new object[] { request.Id }, cancellationToken);
            if (usuario == null)
                throw new Exception($"Usuário com ID {request.Id} não encontrado.");

            return usuario;
        }
    }
}
