using Application.TagCommands.Commands;
using Domain.Entitys;
using Domain.Repositorys;
using FluentValidation;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly IRepository<Tag> _repositoryTag;

        public CreateTagHandler(IRepository<Tag> repositoryTag)
        {
            _repositoryTag = repositoryTag;
        }

        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var tag = new Tag(request.Descricao);
            tag = await _repositoryTag.AddAsync(tag);
            return tag.Id;
        }
    }
}
