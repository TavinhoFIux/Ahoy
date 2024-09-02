using MediatR;

namespace Application.NoticiaCommands.Commands
{
    public class DeleteNoticiaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
