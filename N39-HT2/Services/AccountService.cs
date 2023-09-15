using N39_HT2.Models;
using N39_HT2.Services.Interfaces;

namespace N39_HT2.Services;

public class AccountService : IAccountService
{
    private IEmailSenderService _emailSenderService;
    private IValidatorService _validatorService;

    private List<User> _users;

    public AccountService()
    {
        _emailSenderService = new EmailSenderService();
        _validatorService = new ValidatorService();
        _users = new List<User>();
    }

    public async Task<bool> Register(string firstName, string lastName, string emailAddress, string password)
    {
        if (!_validatorService.IsValidEmailAddress(emailAddress) || !_validatorService.IsValidPassword(password))
            throw new ArgumentException("Email address or password is'nt valid!");

        if (!await _emailSenderService.SendEmail(emailAddress, $"{firstName} {lastName}"))
            throw new InvalidOperationException("There was an error sending email");

        if (_users.Any(user => user.EmailAddress == emailAddress))
            throw new Exception("There is a user with this email");

        _users.Add(new User(firstName, lastName, emailAddress, password));
        return true;

    }
}
