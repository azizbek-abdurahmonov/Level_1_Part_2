﻿namespace N90_HT1.Infrastructure.Common.Settings;

public class VerificationSettings
{
    public string VerificationLink { get; set; } = default!;

    public int VerificationCodeExpiryTimeInSeconds { get; set; }

    public int VerificationCodeLength { get; set; }
}