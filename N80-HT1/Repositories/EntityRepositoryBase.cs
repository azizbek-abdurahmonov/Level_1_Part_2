using Microsoft.EntityFrameworkCore;
using N80_HT1.Caching.Interfaces;
using N80_HT1.Common.Models;
using N80_HT1.Common.Query;
using System.Linq.Expressions;

namespace N80_HT1.Repositories;

public class EntityRepositoryBase<TEntity, TContext>(TContext dbContext, ICacheBroker cacheBroker, CacheEntryOptions? cacheEntryOptions)
    where TEntity : class, IEntity
    where TContext : DbContext
{
    protected TContext DbContext => dbContext;

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (predicate != null) initialQuery = initialQuery.Where(predicate);

        if (asNoTracking) initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    protected async ValueTask<IList<TEntity>> GetAsync(QuerySpecification<TEntity> querySpecification, bool asNoTracking, CancellationToken cancellationToken = default)
    {
        List<TEntity>? foundEntities;

        if(cacheEntryOptions is null || !await cacheBroker.TryGetAsync<List<TEntity>>(querySpecification.CacheKey, out var cachedEntities))
        {
            var initialQuery = DbContext.Set<TEntity>().AsQueryable();

            if (asNoTracking) initialQuery = initialQuery.AsNoTracking();

            initialQuery = initialQuery.ApplySpecification(querySpecification);

            foundEntities = await initialQuery.ToListAsync(cancellationToken);

            if (cacheEntryOptions is not null)
                await cacheBroker.SetAsync(querySpecification.CacheKey, initialQuery);
        }
        else
        {
            foundEntities = cachedEntities;
        }

        return foundEntities;
    }

    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var foundEntity = default(TEntity?);

        if (cacheEntryOptions is null || !await cacheBroker.TryGetAsync<TEntity>(id.ToString(), out var cachedEntity))
        {
            var initialQuery = DbContext.Set<TEntity>().AsQueryable();

            if (asNoTracking) initialQuery = initialQuery.AsNoTracking();

            foundEntity = initialQuery.FirstOrDefault(entity => entity.Id == id);

            if (foundEntity is not null && cacheEntryOptions is not null)
                await cacheBroker.SetAsync(id.ToString(), foundEntity, cacheEntryOptions, cancellationToken);
        }
        else
            foundEntity = cachedEntity;

        return foundEntity;
    }

    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await DbContext.AddAsync(entity, cancellationToken);
        if (cacheEntryOptions is not null) await cacheBroker.SetAsync(entity.Id.ToString(), entity);

        if (saveChanges) await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.Update(entity);
        if(cacheEntryOptions is not null) await cacheBroker.SetAsync(entity.Id.ToString(), entity);

        if(saveChanges) await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundEntity = DbContext.Set<TEntity>().SingleOrDefault(entity => entity.Id == id)
            ?? throw new InvalidOperationException("Entity not found with this Id");

        DbContext.Remove(foundEntity);

        if(cacheEntryOptions is not null) await cacheBroker.DeleteAsync(id.ToString());

        if(saveChanges) await DbContext.SaveChangesAsync(cancellationToken);

        return foundEntity;
    }
}
