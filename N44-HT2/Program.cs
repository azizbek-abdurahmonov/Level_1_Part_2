/*
Defferred execution : Select, Where, OrderBy ...
Immediate execution : ToList, ToArray, ToLookUp, ToDictionary
Mixed execution : Take, Skip, First
*/

using System.Threading.Channels;
using N44_HT2;

var users = new List<User>
{
    new User("Azizbek", 15),
    new User("Bekzod", 15),
    new User("Ilxom", 21),
    new User("Abdurahmon", 20)
};

var updatedUsersQuery = users.Select(user => user.Age += 1);
var oldUsersQuery = users.Where(user => user.Age >= 18);
var orderedUsersQuery = users.OrderBy(user => user.Age);
var updatedUsersList = updatedUsersQuery.ToList();
var oldUsersArray = oldUsersQuery.ToArray();
var firstUser = users.First();
var exampleForTake = users.Take(10);
var exampleForSkip = users.Skip(5);