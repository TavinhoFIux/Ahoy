using Application.NoticiaCommands.Commands;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;


namespace Application.NoticiaCommands.Handlers
{
    public class UpdateNoticiaHandler : IRequestHandler<UpdateNoticiaCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateNoticiaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateNoticiaCommand request, CancellationToken cancellationToken)
        {
            var noticia = await _context.Noticia.FindAsync(request.Id);
            if (noticia == null) throw new Exception("Notícia não encontrada.");

            noticia.Titulo = request.Titulo;
            noticia.Texto = request.Texto;
            _context.Update(noticia);

            var existingTags = _context.NoticiaTags.Where(nt => nt.NoticiaId == noticia.Id).ToList();
            _context.NoticiaTags.RemoveRange(existingTags);
            foreach (var tagId in request.TagIds)
            {
                var noticiaTag = new NoticiaTag { NoticiaId = noticia.Id, TagId = tagId };
                _context.NoticiaTags.Add(noticiaTag);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
