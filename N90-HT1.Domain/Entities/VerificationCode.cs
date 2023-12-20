using N90_HT1.Domain.Common.Entities;
using N90_HT1.Domain.Enums;

namespace N90_HT1.Domain.Entities;

public abstract class VerificationCode : Entity
{
    public VerificationCodeType CodeType { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }

    public bool IsActive { get; set; }

    public string Code { get; set; } = default!;

    public string VerificationLink { get; set; } = default!;
}