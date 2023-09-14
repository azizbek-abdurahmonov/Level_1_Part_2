namespace N38_HT2.Models;

public class BlogPost
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int ReadTime { get; set; }
    public DateOnly CreatedDate { get; set; }

    public override string ToString()
    {
        return $"Id :{Id}, Title: {Title}, Content : {Content}, ReadTime: {ReadTime} min, CreatedDate: {CreatedDate}";
    }
}