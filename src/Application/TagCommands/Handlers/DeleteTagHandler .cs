using Application.TagCommands.Commands;
using Domain.Entitys;
using Domain.Repositorys;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, Unit>
    {
        private readonly IRepository<Tag> _repositoryTag;

        public DeleteTagHandler(IRepository<Tag> repositoryTag)
        {
            _repositoryTag = repositoryTag;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _repositoryTag.GetByIdAsync(request.Id);
            if (tag == null)
                throw new Exception("Tag não encontrada.");

            await _repositoryTag.DeleteAsync(tag);
            return Unit.Value;
        }
    }
}
