namespace N90_HT1.Application.Common.Verifications.Services;

public interface IVerificationProcessingService
{
    ValueTask<bool> Verify(string code, CancellationToken cancellationToken);
}