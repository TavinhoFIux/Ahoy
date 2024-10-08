﻿using Application.TagCommands.Commands;
using Domain.Entitys;
using Domain.Repositorys;
using FluentValidation;
using MediatR;

namespace Application.TagCommands.Handlers
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Unit>
    {
        private readonly IRepository<Tag> _repositoryTag;

        public UpdateTagHandler(IRepository<Tag> repositoryTag)
        {
            _repositoryTag = repositoryTag;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var tag = await _repositoryTag.GetByIdAsync(request.Id);
            if (tag == null)
                throw new Exception("Tag não encontrada.");

            tag.Update(request.Descricao);
            await _repositoryTag.UpdateAsync(tag);
            return Unit.Value;
        }
    }
}
