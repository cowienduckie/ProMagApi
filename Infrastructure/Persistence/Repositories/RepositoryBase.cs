using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T> where T : class
{
    protected readonly DbSet<T> Table;

    public RepositoryBase(EfContext dbContext)
    {
        Table = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        return entity;
    }

    public IQueryable<T> AsQueryable()
    {
        return Table.AsQueryable();
    }

    public Task<bool> DeleteAsync(T entity)
    {
        Table.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        return predicate != null
            ? Table.FirstOrDefaultAsync(predicate, cancellationToken)
            : Table.FirstOrDefaultAsync(cancellationToken);
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return predicate != null
            ? Table.Where(predicate).ToListAsync(cancellationToken)
            : Table.ToListAsync(cancellationToken);
    }

    public Task<T> UpdateAsync(T entity)
    {
        Table.Update(entity);
        return Task.FromResult(entity);
    }
}