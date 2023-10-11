using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Events;

public class AccountEventStore
{
    public event Func<User, ValueTask>? OnUserCreated;

    public async ValueTask CreateUserAddedEventAsync(User user)
    {
        if (OnUserCreated != null)
            await OnUserCreated(user);
    }
}