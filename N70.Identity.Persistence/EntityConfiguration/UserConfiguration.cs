using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Persistence.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Role)
            .WithMany()
            .HasForeignKey(user => user.RoleId);

        builder.HasData(new User
        {
            Id = Guid.Parse("cefdf4ea-215b-45cb-8069-40455d1c8336"),
            FirstName = "Admin",
            LastName = "Admin",
            EmailAddress = "admin",
            PasswordHash = "$2a$11$DjpykDNgRHvY7V5lDo7Wee0vU4t1QIi/QQpVrKy9453t6zC86w74y",
            IsEmailAddressVerified = true,
            RoleId = Guid.Parse("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf")
        });
    }
}