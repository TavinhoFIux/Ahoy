using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsuarioCommands.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
