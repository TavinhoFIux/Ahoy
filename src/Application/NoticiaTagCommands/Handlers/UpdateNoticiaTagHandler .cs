using Application.NoticiaTagCommands.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.NoticiaTagCommands.Handlers
{
    public class UpdateNoticiaTagHandler : IRequestHandler<UpdateNoticiaTagCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateNoticiaTagHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateNoticiaTagCommand request, CancellationToken cancellationToken)
        {
            var noticiaTag = await _context.NoticiaTags.FindAsync(request.Id);
            if (noticiaTag == null)
                throw new Exception("NoticiaTag não encontrada.");

            noticiaTag.NoticiaId = request.NoticiaId;
            noticiaTag.TagId = request.TagId;
            _context.Update(noticiaTag);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
