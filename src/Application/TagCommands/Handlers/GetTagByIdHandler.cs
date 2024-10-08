﻿using Application.TagCommands.Query;
using Domain.Entitys;
using Domain.Repositorys;
using FluentValidation;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, Tag>
    {
        private readonly IRepository<Tag> _repositoryTag;

        public GetTagByIdHandler(IRepository<Tag> repositoryTag)
        {
            _repositoryTag = repositoryTag;
        }

        public async Task<Tag> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var tag = await _repositoryTag.GetByIdAsync(request.Id);
            if (tag == null)
                throw new Exception($"Tag com ID {request.Id} não encontrado.");

            return tag;
        }
    }
}
