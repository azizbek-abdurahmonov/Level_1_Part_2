using CloneGramm.Library.Common;

namespace CloneGramm.Library.Models;

public class Post : SoftDeletedEntity
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public string ImagePath { get; set; }
    public Guid UserId { get; set; }
}
