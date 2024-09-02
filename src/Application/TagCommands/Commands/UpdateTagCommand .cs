using MediatR;


namespace Application.TagCommands.Commands
{
    public class UpdateTagCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
