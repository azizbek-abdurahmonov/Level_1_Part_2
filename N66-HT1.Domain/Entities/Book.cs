namespace N66_HT1.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid AuthorId { get; set; }
}
