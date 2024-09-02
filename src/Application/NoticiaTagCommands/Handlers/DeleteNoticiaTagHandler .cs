using Application.NoticiaTagCommands.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.NoticiaTagCommands.Handlers
{

    public class DeleteNoticiaTagHandler : IRequestHandler<DeleteNoticiaTagCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteNoticiaTagHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteNoticiaTagCommand request, CancellationToken cancellationToken)
        {
            var noticiaTag = await _context.NoticiaTags.FindAsync(request.Id);
            if (noticiaTag == null)
                throw new Exception("NoticiaTag não encontrada.");

            _context.NoticiaTags.Remove(noticiaTag);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
