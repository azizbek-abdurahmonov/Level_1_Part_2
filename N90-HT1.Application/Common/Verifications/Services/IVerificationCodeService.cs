using N90_HT1.Domain.Enums;

namespace N90_HT1.Application.Common.Verifications.Services;

public interface IVerificationCodeService
{
    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}