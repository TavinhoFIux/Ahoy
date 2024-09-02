using Application.NoticiaCommands.Commands;
using Domain.Entitys;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoticiaCommands.Handlers
{
    public class CreateNoticiaHandler : IRequestHandler<CreateNoticiaCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateNoticiaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNoticiaCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync();
            if (usuario == null) 
            {
                throw new Exception("Não existe usuarios cadastrado na base de dados");
            }
            var noticia = new Noticia { Titulo = request.Titulo, Texto = request.Texto, UsuarioId = usuario.Id};
            _context.Noticia.Add(noticia);
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var tagId in request.TagIds)
            {
                var noticiaTag = new NoticiaTag { NoticiaId = noticia.Id, TagId = tagId };
                _context.NoticiaTags.Add(noticiaTag);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return noticia.Id;
        }
    }
}
