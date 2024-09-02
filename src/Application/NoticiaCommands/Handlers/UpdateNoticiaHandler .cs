using Application.NoticiaCommands.Commands;
using Domain.Repositorys;
using FluentValidation;
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
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

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
