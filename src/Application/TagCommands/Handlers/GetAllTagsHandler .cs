using Application.TagCommands.Query;
using Domain.Entitys;
using Domain.Repositorys;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<Tag>>
    {
        private readonly IRepository<Tag> _repositoryTag;

        public GetAllTagsHandler(IRepository<Tag> repositoryTag)
        {
            _repositoryTag = repositoryTag;
        }

        public async Task<IEnumerable<Tag>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryTag.GetAllAsync();
        }
    }
}
