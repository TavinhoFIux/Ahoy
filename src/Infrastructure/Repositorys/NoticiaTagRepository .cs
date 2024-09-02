using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositorys
{
    public class NoticiaTagRepository : Repository<NoticiaTag>, INoticiaTagRepository
    {
        public NoticiaTagRepository(ApplicationDbContext context, ILogger<Repository<NoticiaTag>> logger) : base(context, logger) { }
    }

}
