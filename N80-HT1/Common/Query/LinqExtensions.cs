using N80_HT1.Common.Models;

namespace N80_HT1.Common.Query;

public static class LinqExtensions
{
    public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> source, QuerySpecification<T> qerySpecification)
        where T : IEntity
    {
        source
            .ApplyPredicates(qerySpecification)
            .ApplyOrdering(qerySpecification)
            .ApplyPagination(qerySpecification.PaginationOptions);

        return source;
    }

    public static IEnumerable<T> ApplySpecification<T>(this IEnumerable<T> source, QuerySpecification<T> qerySpecification)
       where T : IEntity
    {
        source
            .ApplyPredicates(qerySpecification)
            .ApplyOrdering(qerySpecification)
            .ApplyPagination(qerySpecification.PaginationOptions);

        return source;
    }

    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> source, FilterPagination paginationOptions)
    {
        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)(paginationOptions.PageSize));
    }

    public static IEnumerable<T> ApplyPagination<T>(this IEnumerable<T> source, FilterPagination paginationOptions)
    {
        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)(paginationOptions.PageSize));
    }

    public static IQueryable<T> ApplyPredicates<T>(this IQueryable<T> source, QuerySpecification<T> querySpecification) where T : IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => source = source.Where(predicate));

        return source;
    }

    public static IEnumerable<T> ApplyPredicates<T>(this IEnumerable<T> source, QuerySpecification<T> querySpecification) where T : IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => source = source.Where(predicate.Compile()));

        return source;
    }

    public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> source, QuerySpecification<T> querySpecification)
        where T : IEntity
    {
        querySpecification
            .OrderingOptions
            .ForEach(order 
                => source = order.IsAscending 
                ? source.OrderBy(order.KeySelector) 
                : source.OrderByDescending(order.KeySelector));

        return source;
    }

    public static IEnumerable<T> ApplyOrdering<T>(this IEnumerable<T> source, QuerySpecification<T> querySpecification)
       where T : IEntity
    {
        querySpecification
            .OrderingOptions
            .ForEach(order
                => source = order.IsAscending
                ? source.OrderBy(order.KeySelector.Compile())
                : source.OrderByDescending(order.KeySelector.Compile()));

        return source;
    }
}
