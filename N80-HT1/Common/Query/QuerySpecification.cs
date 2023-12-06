using N80_HT1.Common.Caching;
using N80_HT1.Common.Comparer;
using N80_HT1.Common.Models;
using System.Linq.Expressions;

namespace N80_HT1.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken)
    : CacheModel where TEntity : IEntity
{
    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = new();

    public List<(Expression<Func<TEntity, object>> KeySelector, bool IsAscending)> OrderingOptions { get; } = new();

    public FilterPagination PaginationOptions = new FilterPagination(pageSize, pageToken);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(filter.ToString());

        foreach (var order in OrderingOptions)
        {
            hashCode.Add(order.ToString());
        }

        hashCode.Add(PaginationOptions.ToString());

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TEntity> querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }

    public override string CacheKey => $"{typeof(TEntity).Name}_{GetHashCode()}";

}
