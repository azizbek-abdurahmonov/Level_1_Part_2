namespace N63_HT1.Models.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; } = default!;

    public bool ValidateIssuerSigningKey { get; set; }

    public string Issuer { get; set; } = string.Empty;

    public bool ValidateIssuer { get; set; }

    public string Audience { get; set; } = string.Empty;

    public bool ValidateAudience { get; set; }

    public int ExpirationTimeInMinutes { get; set; }

    public bool ValidateLifeTime { get; set; }
}
