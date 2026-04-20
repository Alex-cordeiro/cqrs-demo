namespace CQRS.Demo.API.CQRS.Handlers;

public interface ICommandHandler<TCommand>
{
    Task Handle(TCommand command);
}
