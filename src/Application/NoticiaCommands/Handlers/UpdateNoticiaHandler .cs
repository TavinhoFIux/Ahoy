using Application.NoticiaCommands.Commands;
using Domain.Repositorys;
using MediatR;


namespace Application.NoticiaCommands.Handlers
{
    public class UpdateNoticiaHandler : IRequestHandler<UpdateNoticiaCommand, Unit>
    {
        private readonly INoticiaRepository _noticiaRepository;

        public UpdateNoticiaHandler(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task<Unit> Handle(UpdateNoticiaCommand request, CancellationToken cancellationToken)
        {
            await _noticiaRepository.UpdateNoticiaAndTagsAsync(
                request.Id,
                request.Titulo,
                request.Texto,
                request.TagIds
            );

            return Unit.Value;
        }
    }
}
