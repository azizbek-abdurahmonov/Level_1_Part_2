namespace N44_HT2;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public User(string? name, int age)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}