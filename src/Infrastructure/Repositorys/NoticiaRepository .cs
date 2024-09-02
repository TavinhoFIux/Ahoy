using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositorys
{
    public class NoticiaRepository : Repository<Noticia>, INoticiaRepository
    {
        private readonly ILogger<NoticiaRepository> _logger;

        public NoticiaRepository(ApplicationDbContext context, ILogger<NoticiaRepository> logger)
            : base(context, logger)
        {
            _logger = logger;
        }

        public async Task<Noticia?> GetByIdWithTagsAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching Noticia with ID {NoticiaId} along with associated tags.", id);
                var noticia = await _context.Noticia
                    .Include(n => n.NoticiaTags)
                        .ThenInclude(nt => nt.Tag)
                    .FirstOrDefaultAsync(n => n.Id == id);

                if (noticia == null)
                {
                    _logger.LogWarning("Noticia with ID {NoticiaId} not found.", id);
                }

                return noticia;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching Noticia with ID {NoticiaId}.", id);
                throw;
            }
        }

        public async Task<Noticia> AddNoticiaWithTagsAsync(Noticia noticia, List<int> tagIds)
        {
            if (noticia == null)
            {
                _logger.LogError("AddNoticiaWithTagsAsync called with null noticia.");
                throw new ArgumentNullException(nameof(noticia));
            }

            if (tagIds == null)
            {
                _logger.LogError("AddNoticiaWithTagsAsync called with null tagIds.");
                throw new ArgumentNullException(nameof(tagIds));
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _logger.LogInformation("Adding Noticia and associated tags.");
                await _context.Noticia.AddAsync(noticia);
                await _context.SaveChangesAsync();

                foreach (var tagId in tagIds)
                {
                    var noticiaTag = new NoticiaTag(noticia.Id, tagId);
                    await _context.NoticiaTags.AddAsync(noticiaTag);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation("Noticia and associated tags added successfully.");
                return noticia;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding Noticia and associated tags. Rolling back transaction.");
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateNoticiaAndTagsAsync(int noticiaId, string titulo, string texto, List<int> tagIds)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _logger.LogInformation("Updating Noticia with ID {NoticiaId} and associated tags.", noticiaId);

                var noticia = await _context.Noticia.FindAsync(noticiaId);
                if (noticia == null)
                {
                    _logger.LogWarning("Noticia with ID {NoticiaId} not found.", noticiaId);
                    throw new Exception("Notícia não encontrada.");
                }

                noticia.Update(titulo, texto);
                _context.Noticia.Update(noticia);

                var existingTags = _context.NoticiaTags.Where(nt => nt.NoticiaId == noticia.Id).ToList();
                _context.NoticiaTags.RemoveRange(existingTags);

                foreach (var tagId in tagIds)
                {
                    var noticiaTag = new NoticiaTag(noticia.Id, tagId);
                    await _context.NoticiaTags.AddAsync(noticiaTag);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation("Noticia with ID {NoticiaId} and associated tags updated successfully.", noticiaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Noticia with ID {NoticiaId}. Rolling back transaction.", noticiaId);
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}