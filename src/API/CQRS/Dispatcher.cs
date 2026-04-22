using CQRS.Demo.API.CQRS.Handlers;

namespace CQRS.Demo.API.CQRS;

public class Dispatcher
{
    private readonly IServiceProvider _provider;
    public Dispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public Task Send<T>(T command)
    {
        var handler = _provider.GetService<ICommandHandler<T>>();
        return handler.Handle(command);
    }
}
