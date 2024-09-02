using MediatR;

namespace Application.NoticiaCommands.Commands
{
    public class CreateNoticiaCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public List<int> TagIds { get; set; }
    }
}
