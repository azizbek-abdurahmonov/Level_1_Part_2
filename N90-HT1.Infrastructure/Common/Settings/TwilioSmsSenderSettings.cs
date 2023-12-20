namespace N90_HT1.Infrastructure.Common.Settings;

public class TwilioSmsSenderSettings
{
    public string AccountSid { get; set; } = default!;

    public string AuthToken { get; set; } = default!;

    public string SenderPhoneNumber { get; set; } = default!;
}