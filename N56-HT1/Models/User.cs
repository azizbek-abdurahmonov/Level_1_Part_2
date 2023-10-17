namespace N56_HT1.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public User(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
