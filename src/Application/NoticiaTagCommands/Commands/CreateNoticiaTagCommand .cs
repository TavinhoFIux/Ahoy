using MediatR;

namespace Application.NoticiaTagCommands.Commands
{
    public class CreateNoticiaTagCommand : IRequest<int>
    {
        public int NoticiaId { get; set; }
        public int TagId { get; set; }
    }

}
