using Application.TagCommands.Commands;
using Infrastructure.Data;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateTagHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tag.FindAsync(request.Id);
            if (tag == null)
                throw new Exception("Tag não encontrada.");

            tag.Descricao = request.Descricao;
            _context.Update(tag);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
