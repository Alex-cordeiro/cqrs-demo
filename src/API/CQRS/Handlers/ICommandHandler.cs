using CQRS.Demo.API.Models;

namespace CQRS.Demo.API.CQRS.Handlers;

public interface ICommandHandler<TCommand>
{
    Result result {get; set; }
    Task<Result> Handle(TCommand command);
}
