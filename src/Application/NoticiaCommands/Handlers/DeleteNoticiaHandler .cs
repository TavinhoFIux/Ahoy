using Application.NoticiaCommands.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.NoticiaCommands.Handlers
{
    public class DeleteNoticiaHandler : IRequestHandler<DeleteNoticiaCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteNoticiaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteNoticiaCommand request, CancellationToken cancellationToken)
        {
            var noticia = await _context.Noticia.FindAsync(request.Id);
            if (noticia == null) throw new Exception("Notícia não encontrada.");

            _context.Noticia.Remove(noticia);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
