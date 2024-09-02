using MediatR;

namespace Application.TagCommands.Commands
{
    public class DeleteTagCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

}
