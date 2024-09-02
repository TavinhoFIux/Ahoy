using MediatR;

namespace Application.NoticiaTagCommands.Commands
{
    public class DeleteNoticiaTagCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
