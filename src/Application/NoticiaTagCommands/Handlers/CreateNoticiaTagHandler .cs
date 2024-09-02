using Application.NoticiaTagCommands.Commands;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;

namespace Application.NoticiaTagCommands.Handlers
{
    public class CreateNoticiaTagHandler : IRequestHandler<CreateNoticiaTagCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateNoticiaTagHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNoticiaTagCommand request, CancellationToken cancellationToken)
        {
            var noticiaTag = new NoticiaTag { NoticiaId = request.NoticiaId, TagId = request.TagId };
            _context.NoticiaTags.Add(noticiaTag);
            await _context.SaveChangesAsync(cancellationToken);
            return noticiaTag.Id;
        }
    }
}
