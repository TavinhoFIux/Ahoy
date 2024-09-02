using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TagCommands.Commands
{
    public class CreateTagCommand : IRequest<int>
    {
        public string Descricao { get; set; }
    }
}
