using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Notifications.Services;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IUserService _userService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AccountService(
        IVerificationTokenGeneratorService verificationTokenGeneratorService,
        IUserService userService,
        IEmailOrchestrationService emailOrchestrationService)
    {
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _userService = userService;
        _emailOrchestrationService = emailOrchestrationService;
    }

    public ValueTask<bool> VerificateUserAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException("Invalid verification token!");

        var decodedToken = _verificationTokenGeneratorService.DecodeToken(token);

        if (!decodedToken.IsValid)
            throw new InvalidOperationException("Verification token is invalid!");

        var result = decodedToken.Token.VerificationType switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(decodedToken.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }

    public async ValueTask<User> CreateUserAsync(User user)
    {
        await _userService.CreateAsync(user);

        var token = _verificationTokenGeneratorService.Generate(VerificationType.EmailAddressVerification, user.Id);

        await _emailOrchestrationService.SendAsync(user.EmailAddress, token);

        return user;
    }

    private async ValueTask<bool> MarkEmailAsVerifiedAsync(Guid id)
    {
        var found = await _userService.GetByIdAsync(id);

        found.IsEmailAddressVerified = true;

        
        await _userService.UpdateAsync(found);

        return true;
    }
}