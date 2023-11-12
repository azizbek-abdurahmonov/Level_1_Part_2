var users = new List<User>
{
    new User("Gishtmat", "Gishtmatov", 15),
    new User("Toshmat", "Toshmatov", 14),
    new User("Abdura", "Abdura", 13),
    new User("Marmok", "CsGo", 12)
};

var service = new UserService();


var addedAges = service.AddAge(users);

Console.WriteLine(addedAges);

//foreach (var user in service.AddAge(users))
//{
//    Console.WriteLine($"{user.FirstName} {user.Age}");
//}

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public User(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}

public class UserService
{
    public IEnumerable<User> AddAge(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} bilan amal boshlandi");
            user.Age = user.Age + 1;
            yield return user;
        }
    }
}