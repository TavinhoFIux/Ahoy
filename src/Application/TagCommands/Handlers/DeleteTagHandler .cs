using Application.TagCommands.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTagHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tag.FindAsync(request.Id);
            if (tag == null)
                throw new Exception("Tag não encontrada.");

            _context.Tag.Remove(tag);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
