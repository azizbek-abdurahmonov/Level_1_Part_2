using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Models;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string Generate(VerificationType verificationType, Guid userId);

    (VerificationToken Token, bool IsValid) DecodeToken(string token);
}