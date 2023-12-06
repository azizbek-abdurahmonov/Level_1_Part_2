namespace N80_HT1.Common.Models;

public class CacheEntryOptions
{
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }

    public TimeSpan? SlidingExpiration { get; set; }

    public CacheEntryOptions()
    {
        
    }

    public CacheEntryOptions(TimeSpan? absoluteExpirationTimeRelativeToNow, TimeSpan? slidingExpiration)
    {
        AbsoluteExpirationRelativeToNow = absoluteExpirationTimeRelativeToNow;
        SlidingExpiration = slidingExpiration;
    }
}


