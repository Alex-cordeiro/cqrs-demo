using System.Linq.Expressions;
using CQRS.Demo.API.Models;

namespace CQRS.Demo.API.Data.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<bool> Add(T entity);
    IEnumerable<T?> Get(bool isReadOnly = true, Expression<Func<T, bool>>? expression = null, string[]? includes = null);
    Task<PagedResponse<T>> GetPaged(int page, int take, Expression<Func<T, bool>> expression);
    Task<T?> GetById(Guid id);
    Task<bool> Remove(T entity);
    Task<bool> Update(T entity);
    Task<bool> Exist(Guid id);
    Task Commit();
}
