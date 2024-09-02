using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;

namespace Infrastructure.Repositorys
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context) { }
    }
}
