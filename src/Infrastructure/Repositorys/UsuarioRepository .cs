using Domain.Entitys;
using Domain.Repositorys;
using Infrastructure.Data;

namespace Infrastructure.Repositorys
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context) { }
    }
}
