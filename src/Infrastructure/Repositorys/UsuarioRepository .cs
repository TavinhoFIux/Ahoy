using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositorys
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context, ILogger<Repository<Usuario>> logger) : base(context, logger) { }
    }
}
