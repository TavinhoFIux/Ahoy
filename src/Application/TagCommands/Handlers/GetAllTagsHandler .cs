using Application.TagCommands.Query;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TagCommands.Handlers
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, List<Tag>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllTagsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tag.ToListAsync(cancellationToken);
        }
    }
}
