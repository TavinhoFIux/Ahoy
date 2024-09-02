using Application.NoticiaCommands.Query;
using Domain.Entitys;
using Domain.Repositorys;
using FluentValidation;
using MediatR;

namespace Application.NoticiaCommands.Handlers
{
    public class GetNoticiaByIdHandler : IRequestHandler<GetNoticiaByIdQuery, Noticia>
    {
        private readonly INoticiaRepository _noticiaRepository;

        public GetNoticiaByIdHandler(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task<Noticia> Handle(GetNoticiaByIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var noticia = await _noticiaRepository.GetByIdWithTagsAsync(request.Id);

            if (noticia == null)
            {
                return null;
            }

            return noticia;
        }
    }
}
