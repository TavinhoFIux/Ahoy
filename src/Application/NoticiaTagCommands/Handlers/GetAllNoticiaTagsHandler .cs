using Application.NoticiaTagCommands.Query;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NoticiaTagCommands.Handlers
{
    public class GetAllNoticiaTagsHandler : IRequestHandler<GetAllNoticiaTagsQuery, List<NoticiaTag>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllNoticiaTagsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NoticiaTag>> Handle(GetAllNoticiaTagsQuery request, CancellationToken cancellationToken)
        {
            return await _context.NoticiaTags.ToListAsync(cancellationToken);
        }
    }
}
