using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys
{
    public class NoticiaRepository : Repository<Noticia>, INoticiaRepository
    {
        public NoticiaRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Noticia> GetByIdWithTagsAsync(int id)
        {
            try
            {
                var noticia = await _context.Noticia
                    .Include(n => n.NoticiaTags)
                        .ThenInclude(nt => nt.Tag)
                    .FirstOrDefaultAsync(n => n.Id == id);
                return noticia;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Noticia> AddNoticiaWithTagsAsync(Noticia noticia, List<int> tagIds)
        {
            if (noticia == null)
                throw new ArgumentNullException(nameof(noticia));
            if (tagIds == null)
                throw new ArgumentNullException(nameof(tagIds));

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Noticia.AddAsync(noticia);
                await _context.SaveChangesAsync();

                foreach (var tagId in tagIds)
                {
                    var noticiaTag = new NoticiaTag(noticia.Id, tagId);
                    await _context.NoticiaTags.AddAsync(noticiaTag);
                }
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return noticia;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateNoticiaAndTagsAsync(int noticiaId, string titulo, string texto, List<int> tagIds)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var noticia = await _context.Noticia.FindAsync(noticiaId);
                if (noticia == null)
                    throw new Exception("Notícia não encontrada.");

                noticia.Update(titulo, texto);
                _context.Noticia.Update(noticia);

                var existingTags = _context.NoticiaTags.Where(nt => nt.NoticiaId == noticia.Id).ToList();
                _context.NoticiaTags.RemoveRange(existingTags);

                foreach (var tagId in tagIds)
                {
                    var noticiaTag = new NoticiaTag(noticia.Id, tagId);
                    _context.NoticiaTags.Add(noticiaTag);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
