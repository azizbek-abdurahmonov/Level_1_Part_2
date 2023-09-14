using System.Threading.Channels;
using N38_HT1.Models;

var users = new List<User>
{
    new User("Azizbek", "Abdurahmonov", "abdura@gmail.com"),
    new User("Abdurahmon", "Satriddinov", "abdurahmonsr@gmail.com"),
    new User("Ilxom", "Karimjanov", "Ilxom@mail.ru"),
    new User("Firdavs", "Asadov", "asadov0@gmail.com"),
    new User("Firdavs", "Tolibov", "marmokcsgo@gmail.com")
};

var userContainer = new UserContainer(users);
var query = userContainer.Where(user => user.EmailAddress.Contains("gmail"));

Console.WriteLine("Emaili gmail.com bo'lganlar :");
foreach (var user in query)
{
    Console.WriteLine(user);
}

Console.WriteLine();

Console.WriteLine(userContainer[userContainer.LastOrDefault().Id]);
Console.WriteLine(userContainer["abdurahmon"]);
Console.WriteLine(userContainer[2]);
