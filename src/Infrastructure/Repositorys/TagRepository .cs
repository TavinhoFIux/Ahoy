using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositorys
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context, ILogger<Repository<Tag>> logger)
            : base(context, logger)
        {
        }
    }
}
