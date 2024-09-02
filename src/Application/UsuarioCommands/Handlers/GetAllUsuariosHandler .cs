using Application.UsuarioCommands.Query;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsuarioCommands.Handlers
{
    public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosQuery, List<Usuario>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsuariosHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuario.ToListAsync(cancellationToken);
        }
    }
}
