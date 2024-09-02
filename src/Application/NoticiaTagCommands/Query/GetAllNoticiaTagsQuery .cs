using Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NoticiaTagCommands.Query
{
    public class GetAllNoticiaTagsQuery : IRequest<List<NoticiaTag>>
    {
    }
}
