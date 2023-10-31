using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Application.Common.Notification.Services;
using N64.Identity.Domain.Entity;
using N64.Identity.Application.Common.Enums;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private List<User> _users = new();
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;

    public List<User> Users => _users;


    public AccountService(IEmailOrchestrationService emailOrchestrationService,
        IVerificationTokenGeneratorService verificationTokenGeneratorService)
    {
        _emailOrchestrationService = emailOrchestrationService;
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
    }

    public async ValueTask<User> CreateUserAsync(User user)
    {
        _users.Add(user);

        var token = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, user.Id);

        await _emailOrchestrationService.SendAsync(user.EmailAddress, token);

        return (user);
    }

    private ValueTask<bool> MarkEmailAsVerifiesAsync(Guid userId)
    {
        var foundUser = _users.FirstOrDefault(x => x.Id == userId)
            ?? throw new ArgumentNullException("User not found!");

        foundUser.IsEmailAddressVerified = true;

        return new(true);
    }

    public ValueTask<bool> VerificateAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token!", nameof(token));

        var decodedVerificationToken = _verificationTokenGeneratorService.DecodeToken(token);

        if (!decodedVerificationToken.IsValid)
            throw new InvalidOperationException("Invalid verification token!");

        var result = decodedVerificationToken.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiesAsync(decodedVerificationToken.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }
}
