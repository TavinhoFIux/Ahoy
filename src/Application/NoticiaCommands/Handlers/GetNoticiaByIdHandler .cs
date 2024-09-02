using Application.NoticiaCommands.Query;
using Domain.Entitys;
using Domain.Repositorys;
using MediatR;

namespace Application.NoticiaCommands.Handlers
{
    public class GetNoticiaByIdHandler : IRequestHandler<GetNoticiaByIdQuery, Noticia>
    {
        private readonly IRepository<NoticiaTag> _repositoryNoticiaTag;
        private readonly IRepository<Tag> _repositoryTag;
        private readonly INoticiaRepository _noticiaRepository;


        public GetNoticiaByIdHandler(IRepository<NoticiaTag> repositoryNoticiaTag, IRepository<Tag> repositoryTag, INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
            _repositoryNoticiaTag = repositoryNoticiaTag;
            _repositoryTag = repositoryTag;
        }

        public async Task<Noticia> Handle(GetNoticiaByIdQuery request, CancellationToken cancellationToken)
        {
            var noticia = await _noticiaRepository.GetByIdWithTagsAsync(request.Id);

            if (noticia == null)
            {
                return null;
            }

            return noticia;
        }
    }
}
