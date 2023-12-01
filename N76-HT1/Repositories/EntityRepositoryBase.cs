using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N76_HT1.Models.Common;

namespace N76_HT1.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
{
    private readonly DbContext _dbContext;
    protected TContext DbContext => (TContext)_dbContext;

    public EntityRepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, bool asNoTracking = false)
    {
        var initialQuery = _dbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    protected ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        if (asNoTracking)
            return new(_dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken: cancellationToken));

        return _dbContext.Set<TEntity>().FindAsync(id);
    }

    protected ValueTask<ICollection<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        var initialQuery = _dbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return new(initialQuery.Where(entity => ids.Contains(entity.Id)).ToList());
    }

    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        _dbContext.Add(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().Update(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity?> DeleteAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity?> DeleteByIdAsync(Guid id, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var found = await _dbContext.Set<TEntity>().FindAsync(id);

        _dbContext.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);

        return found;
    }
}