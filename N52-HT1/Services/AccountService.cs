using N52_HT1.Events;
using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Services;

public class AccountService : IAccountService
{
    private AccountEventStore _eventStore;
    private IEmailSenderService _emailSender;

    public AccountService(AccountEventStore eventStore, IEmailSenderService emailSender)
    {
        _eventStore = eventStore;
        _emailSender = emailSender;

        _eventStore.OnUserCreated += HandleUserCreatedEventAsync;
    }

    public async ValueTask HandleUserCreatedEventAsync(User user)
    {
        await _emailSender.SendEmailAsync(user);
    }
}