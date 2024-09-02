using Application.NoticiaCommands.Commands;
using Domain.Repositorys;
using MediatR;

namespace Application.NoticiaCommands.Handlers
{
    public class DeleteNoticiaHandler : IRequestHandler<DeleteNoticiaCommand, Unit>
    {
        private readonly INoticiaRepository _repositoryNoticia;

        public DeleteNoticiaHandler(INoticiaRepository repositoryNoticia)
        {
            _repositoryNoticia = repositoryNoticia;
        }

        public async Task<Unit> Handle(DeleteNoticiaCommand request, CancellationToken cancellationToken)
        {
            var noticia = await _repositoryNoticia.GetByIdAsync(request.Id);
            if (noticia == null) throw new Exception("Notícia não encontrada.");

            await _repositoryNoticia.DeleteAsync(noticia);
            return Unit.Value;
        }
    }
}
