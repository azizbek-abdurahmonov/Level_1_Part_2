using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N76_HT1.Entities;

namespace N76_HT1.EntityConfiguration;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(126);

        builder.Property(user => user.LastName).IsRequired().HasMaxLength(126);
    }
}
