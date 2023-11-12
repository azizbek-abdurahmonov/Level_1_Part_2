using N71_HT1.Domain.Common;

namespace N71_HT1.Domain.Entities;

public class Blog : IEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid AuthorId { get; set; }

    public virtual User Author { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}