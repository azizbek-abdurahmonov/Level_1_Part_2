namespace N66_HT1.Application.Common.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; } = default!;

    public bool ValidateIssuer { get; set; }

    public string ValidIssuer { get; set; } = default!;

    public bool ValidateAudience { get; set; }

    public string ValidAudience { get; set; } = default!;

    public bool ValidateLifeTime { get; set; }

    public bool ValidateIssuerSigningKey { get; set; }

    public int ExpiryTimeInMinutes { get; set; }
}
