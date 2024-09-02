using Application.NoticiaCommands.Query;
using Domain.Entitys;
using Domain.Repositorys;
using MediatR;

namespace Application.NoticiaCommands.Handlers
{
    public class GetAllNoticiasHandler : IRequestHandler<GetAllNoticiasQuery, IEnumerable<Noticia>>
    {
        private readonly INoticiaRepository _repositoryNoticia;

        public GetAllNoticiasHandler(INoticiaRepository repositoryNoticia)
        {
            _repositoryNoticia = repositoryNoticia;
        }

        public async Task<IEnumerable<Noticia>> Handle(GetAllNoticiasQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryNoticia.GetAllAsync();
        }
    }
}
