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
    }
}
