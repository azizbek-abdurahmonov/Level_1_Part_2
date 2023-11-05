namespace N67.Identity.Domain.Entities;

public class UserSettings
{
    public Guid Id { get; set; }
    
    public bool DarkModeEnabled { get; set; }
    
    public Guid UserId { get; set; }
}