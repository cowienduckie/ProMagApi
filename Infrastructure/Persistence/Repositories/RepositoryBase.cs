using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T> where T : class
{
    protected readonly DbSet<T> DbSet;

    public RepositoryBase(EfContext dbContext)
    {
        DbSet = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public Task<bool> DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        return predicate != null
            ? DbSet.FirstOrDefaultAsync(predicate, cancellationToken)
            : DbSet.FirstOrDefaultAsync(cancellationToken);
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return predicate != null
            ? DbSet.Where(predicate).ToListAsync(cancellationToken)
            : DbSet.ToListAsync(cancellationToken);
    }

    public Task<T> UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        return Task.FromResult(entity);
    }
}