namespace DbContextExample.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid AuthorId { get; set; }

    public virtual Author Author { get; set; }
}
