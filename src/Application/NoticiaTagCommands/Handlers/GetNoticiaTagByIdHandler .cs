using Application.NoticiaTagCommands.Query;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoticiaTagCommands.Handlers
{
    public class GetNoticiaTagByIdHandler : IRequestHandler<GetNoticiaTagByIdQuery, NoticiaTag>
    {
        private readonly ApplicationDbContext _context;

        public GetNoticiaTagByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NoticiaTag> Handle(GetNoticiaTagByIdQuery request, CancellationToken cancellationToken)
        {
            var noticiaTag = await _context.NoticiaTags.FirstOrDefaultAsync(nt => nt.Id == request.Id, cancellationToken);

            if (noticiaTag == null)
                throw new Exception($"NoticiaTag com ID {request.Id} não encontrada.");

            return noticiaTag;
        }
    }
}
