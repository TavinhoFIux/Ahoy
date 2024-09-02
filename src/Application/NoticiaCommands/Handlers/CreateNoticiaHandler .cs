using Application.NoticiaCommands.Commands;
using Domain.Entitys;
using Domain.Repositorys;
using FluentValidation;
using MediatR;

namespace Application.NoticiaCommands.Handlers
{
    public class CreateNoticiaHandler : IRequestHandler<CreateNoticiaCommand, int>
    {
        private readonly INoticiaRepository _repositoryNoticia;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public CreateNoticiaHandler(INoticiaRepository repositoryNoticia, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryNoticia = repositoryNoticia;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<int> Handle(CreateNoticiaCommand request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var usuario = await _repositoryUsuario.GetByIdAsync(1);

            if (usuario == null) 
            {
                throw new Exception("Não existe usuarios cadastrado na base de dados");
            }

            var noticia = new Noticia(request.Titulo, request.Texto, usuario.Id);

            noticia = await _repositoryNoticia.AddNoticiaWithTagsAsync(noticia, request.TagIds);

            return noticia.Id;
        }
    }
}
