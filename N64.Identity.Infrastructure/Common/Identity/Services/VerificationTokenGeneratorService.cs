using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Application.Common.Settings;
using System.Text.Json;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _dataProtector;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public VerificationTokenGeneratorService(IDataProtectionProvider dataProtectionProvider, IOptions<VerificationTokenSettings> verificationTokenSettings)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _dataProtector = dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }

    public (VerificationToken Token, bool IsValid) DecodeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));

        var unprotectedToken = _dataProtector.Unprotect(token);

        var verificationToken = JsonSerializer.Deserialize<VerificationToken>(unprotectedToken)
            ?? throw new ArgumentException("Invalid verification model", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }

    public string GenerateToken(VerificationType type, Guid id)
    {
        return _dataProtector.Protect(JsonSerializer.Serialize(new VerificationToken
        {
            UserId = id,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        }));
    }
}
