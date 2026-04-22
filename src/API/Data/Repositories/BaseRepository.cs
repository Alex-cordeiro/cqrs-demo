using System.Linq.Expressions;
using CQRS.Demo.API.Data.Interfaces;
using CQRS.Demo.API.Domain.Base;
using CQRS.Demo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Demo.API.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly Context _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(Context context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public async Task<bool> Add(T entity)
    {
        try 
        {
            await _dbSet.AddAsync(entity);
            return true;
        }
        catch(DbUpdateException)
        {
            throw; 
        }
    }

    public async Task Commit()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateException)
        {
            throw; 
        }
    }

    public async Task<bool> Exist(Guid id) => await _dbSet.AnyAsync(x => x.Id == id);


    public IEnumerable<T?> Get(bool isReadOnly = true, Expression<Func<T, bool>>? expression = null, string[]? includes = null)
    {
        var query = isReadOnly ? _dbSet.AsNoTracking() : _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (expression != null)
            return query.Where(expression).AsQueryable();

        return query.AsQueryable();
    }

    public async Task<T?> GetById(Guid id) => await _dbSet.FindAsync(id);

    public async Task<PagedResponse<T>> GetPaged(int page, int take, Expression<Func<T, bool>> expression)
    {
        var rowCount = _dbSet.Count();
        var pageCount = (decimal)rowCount / take;

        var resultCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * take;

        var resultQuery = _dbSet.Where(expression).OrderBy(x => x.Id).Skip(skip).Take(take).ToList();

        return await Task.FromResult(new PagedResponse<T>()
        {
            CurrentPage = page,
            PageSize = take,
            TotalCount = resultCount,
            Data = resultQuery
        });
    }

    public Task<bool> Remove(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }
        catch(DbUpdateException)
        {
            throw;
        }
    }

    public Task<bool> Update(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            return Task.FromResult(true);
        }
        catch(DbUpdateException)
        {
            throw;
        }
    }
}
