namespace N38_HT1.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }

    public User(string firstName, string lastName, string emailAddress)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
    }

    public override string ToString()
    {
        return $"FirstName: {FirstName}, LastName : {LastName}, Email : {EmailAddress}";
    }
}