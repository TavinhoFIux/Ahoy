using Domain.Entitys;

namespace Domain.Repositorys
{
    public interface INoticiaRepository : IRepository<Noticia> 
    {
        Task<Noticia?> GetByIdWithTagsAsync(int id);
        Task<Noticia> AddNoticiaWithTagsAsync(Noticia noticia, List<int> tagIds);
        Task UpdateNoticiaAndTagsAsync(int noticiaId, string titulo, string texto, List<int> tagIds);
    }
}
