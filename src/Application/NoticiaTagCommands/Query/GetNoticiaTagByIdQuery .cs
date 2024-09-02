using Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NoticiaTagCommands.Query
{
    public class GetNoticiaTagByIdQuery : IRequest<NoticiaTag>
    {
        public int Id { get; set; }

        public GetNoticiaTagByIdQuery(int id)
        {
            Id = id;
        }
    }
}
