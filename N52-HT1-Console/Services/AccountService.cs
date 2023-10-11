using N52_HT1_Console.Events;
using N52_HT1_Console.Models;
using N52_HT1_Console.Services.Interfaces;

namespace N52_HT1_Console.Services;

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
        Console.WriteLine("Email yuborilmoqdaa...");
        await _emailSender.SendEmailAsync(user);
    }
}