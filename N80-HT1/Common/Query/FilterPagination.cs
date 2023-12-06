namespace N80_HT1.Common.Query;

public class FilterPagination
{
    public uint PageSize { get; set; }

    public uint PageToken { get; set; }

    public FilterPagination()
    {
        
    }

    public FilterPagination(uint pageSize, uint pageToken)
    {
        PageSize = pageSize;
        PageToken = pageToken;
    }
}
