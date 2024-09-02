using MediatR;

namespace Application.NoticiaCommands.Commands
{
    public class UpdateNoticiaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public List<int> TagIds { get; set; }
    }
}
