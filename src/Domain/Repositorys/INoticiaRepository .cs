using Domain.Entitys;

namespace Domain.Repositorys
{
    public interface INoticiaRepository : IRepository<Noticia> 
    {
        Task<Noticia> GetByIdWithTagsAsync(int id);
    }
}
