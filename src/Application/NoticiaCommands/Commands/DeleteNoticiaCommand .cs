using Application.Utils;
using MediatR;

namespace Application.NoticiaCommands.Commands
{
    public class DeleteNoticiaCommand : Command<Unit>
    {
        public int Id { get; set; }
    }
}
