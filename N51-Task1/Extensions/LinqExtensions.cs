using System.ComponentModel;

namespace N51_Task1.Extensions;

public static class LinqExtensions
{
    public static IEnumerable<(TSource, TSource)> ZipIntersectBy<TSource, TKey>(
        this IEnumerable<TSource> sourceA,
        IEnumerable<TSource> sourceB,
        Func<TSource, TKey> keySelector
    ) where TKey : notnull
    {
        if (sourceA is null)
            throw new ArgumentNullException(nameof(sourceA));

        if (sourceB is null)
            throw new ArgumentNullException(nameof(sourceB));

        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));

        return ZipIntersectIterator(sourceA, sourceB, keySelector);
    }
    
    private static IEnumerable<(TSource, TSource)> ZipIntersectIterator<TSource, TKey>(
        this IEnumerable<TSource> sourceA,
        IEnumerable<TSource> sourceB,
        Func<TSource, TKey> keySelector) where TKey : notnull
    {
        foreach (var itemA in sourceA)
        {
            var key = keySelector(itemA);

            var itemB = sourceB.FirstOrDefault(x => keySelector(x).Equals(key));

            if (itemB != null)
                yield return (itemA, itemB);
        }
    }
}