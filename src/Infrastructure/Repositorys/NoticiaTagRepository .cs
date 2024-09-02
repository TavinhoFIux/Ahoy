using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;

namespace Infrastructure.Repositorys
{
    public class NoticiaTagRepository : Repository<NoticiaTag>, INoticiaTagRepository
    {
        public NoticiaTagRepository(ApplicationDbContext context) : base(context) { }
    }

}
