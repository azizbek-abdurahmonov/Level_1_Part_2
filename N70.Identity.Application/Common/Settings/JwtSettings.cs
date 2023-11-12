namespace N70.Identity.Application.Common.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; } = default!;

    public string ValidIssuer { get; set; } = default!;

    public bool ValidateIssuer { get; set; }

    public string ValidAudience { get; set; } = default!;

    public bool ValidateAudience { get; set; }

    public int ExpirationTimeInMinutes { get; set; }

    public bool ValidateLifeTime { get; set; }

    public bool ValidateIssuerSigningKey { get; set; }
}