namespace N67.Identity.Domain.Entities;

public class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
}