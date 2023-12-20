﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N90_HT1.Domain.Entities;

namespace N90_HT1.Persistence.EntityConfigurations;

public class UserInfoVerificationCodeConfiguration : IEntityTypeConfiguration<UserInfoVerificationCode>
{
    public void Configure(EntityTypeBuilder<UserInfoVerificationCode> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(code => code.UserId);
    }
}