using Application.TagCommands.Commands;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateTagHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = new Tag { Descricao = request.Descricao };
            _context.Tag.Add(tag);
            await _context.SaveChangesAsync(cancellationToken);
            return tag.Id;
        }
    }
}
