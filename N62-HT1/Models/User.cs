namespace N62_HT1.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
