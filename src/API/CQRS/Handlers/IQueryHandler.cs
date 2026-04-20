namespace CQRS.Demo.API.CQRS.Handlers;

public interface IQueryHandler<TQuery, TResult>
{
    Task<TResult> Handle(TQuery query);
}