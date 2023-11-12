using N71_HT1.Domain.Common;

namespace N71_HT1.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string EmailAddress { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public virtual ICollection<Blog> BlogPosts { get; set; } = new List<Blog>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}