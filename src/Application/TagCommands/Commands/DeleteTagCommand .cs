using Application.Utils;
using MediatR;

namespace Application.TagCommands.Commands
{
    public class DeleteTagCommand : Command<Unit>
    {
        public int Id { get; set; }
    }

}
