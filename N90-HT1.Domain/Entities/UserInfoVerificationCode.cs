using N90_HT1.Domain.Enums;

namespace N90_HT1.Domain.Entities;

public class UserInfoVerificationCode : VerificationCode
{
    public UserInfoVerificationCode()
    {
        Type = VerificationType.UserInfoVerificationCode;
    }

    public Guid UserId { get; set; }
}