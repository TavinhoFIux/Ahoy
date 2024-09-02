using Application.NoticiaCommands.Query;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoticiaCommands.Handlers
{
    public class GetAllNoticiasHandler : IRequestHandler<GetAllNoticiasQuery, List<Noticia>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllNoticiasHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Noticia>> Handle(GetAllNoticiasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Noticia.ToListAsync(cancellationToken);
        }
    }
}
