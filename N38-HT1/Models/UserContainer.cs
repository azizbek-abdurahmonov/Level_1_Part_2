using System.Collections;

namespace N38_HT1.Models;

public class UserContainer : IEnumerable<User>
{
    private IEnumerable<User> _users;

    public UserContainer()
    {
        _users = new List<User>();
    }

    public UserContainer(IEnumerable<User> users)
    {
        _users = users;
    }

    public User this[Guid id] => _users.First(user => user.Id == id);

    public User this[string keyword]
        => _users.First(user => user.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                || user.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                || user.EmailAddress.Contains(keyword, StringComparison.OrdinalIgnoreCase));

    public User this[int index] => _users.ToArray()[index];

    IEnumerator<User> IEnumerable<User>.GetEnumerator()
    {
        return _users.GetEnumerator();
    }

    public IEnumerator GetEnumerator()
    {
        return _users.GetEnumerator();
    }
}