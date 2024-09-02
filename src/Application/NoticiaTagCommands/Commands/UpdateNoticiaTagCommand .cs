using MediatR;

namespace Application.NoticiaTagCommands.Commands
{
    public class UpdateNoticiaTagCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int NoticiaId { get; set; }
        public int TagId { get; set; }
    }
}
