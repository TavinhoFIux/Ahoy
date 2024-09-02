using Application.TagCommands.Query;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, Tag>
    {
        private readonly ApplicationDbContext _context;

        public GetTagByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tag.FindAsync(new object[] { request.Id }, cancellationToken);
            if (tag == null)
                throw new Exception($"Tag com ID {request.Id} não encontrado.");

            return tag;
        }
    }
}
