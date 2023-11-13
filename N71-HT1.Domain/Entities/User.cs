using N71_HT1.Domain.Common;
using System.Text.Json.Serialization;

namespace N71_HT1.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string EmailAddress { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<Blog> BlogPosts { get; set; } = new List<Blog>();

    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}