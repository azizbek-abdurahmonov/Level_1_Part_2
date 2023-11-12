namespace N70.Identity.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string VerificationTokenPurpose { get; set; } = default!;

    public int VerificationTokenExpirationDurationInMinutes { get; set; }
}