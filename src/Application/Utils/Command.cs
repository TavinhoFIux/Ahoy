using FluentValidation.Results;
using MediatR;


namespace Application.Utils
{
    public class Command<T> : IRequest<T>
    {
        public DateTimeOffset Timestamp { get; }

        protected Command()
        {
            Timestamp = DateTimeOffset.UtcNow;
        }

        public virtual ValidationResult Validate()
        {
            throw new NotImplementedException();
        }
    }
}
