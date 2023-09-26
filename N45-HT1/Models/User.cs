namespace N45_HT1.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }

    public User(string firstName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
    }
}
