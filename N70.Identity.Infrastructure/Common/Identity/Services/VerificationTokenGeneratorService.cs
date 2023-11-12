using System.Text.Json;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Settings;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly VerificationTokenSettings _verificationTokenSettings;
    private readonly IDataProtector _dataProtector;

    public VerificationTokenGeneratorService(
        IOptions<VerificationTokenSettings> verificationTokenSettings,
        IDataProtectionProvider dataProtectionProvider)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _dataProtector = dataProtectionProvider.CreateProtector(_verificationTokenSettings.VerificationTokenPurpose);
    }

    public string Generate(VerificationType verificationType, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            VerificationType = verificationType,
            ExpiryTime =
                DateTimeOffset.Now.AddMinutes(_verificationTokenSettings.VerificationTokenExpirationDurationInMinutes)
        };

        var token = _dataProtector.Protect(JsonSerializer.Serialize(verificationToken));

        return token;
    }

    public (VerificationToken Token, bool IsValid) DecodeToken(string token)
    {
        var unprotectedToken = _dataProtector.Unprotect(token);
        var verificationToken = JsonSerializer.Deserialize<VerificationToken>(unprotectedToken)
                                ?? throw new ArgumentException("Invalid verification token", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.Now);
    }
}