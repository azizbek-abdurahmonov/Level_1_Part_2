using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71_HT1.Domain.Entities;

namespace N71_HT1.Persistence.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Id = Guid.Parse("dc25f9aa-78ce-4621-bb9b-f312fa9f1a65"),
            FirstName = "Admin",
            LastName = "Admin",
            EmailAddress = "admin",
            PasswordHash = "$2a$11$krR1I/7dXArgaIE7ne6HrulVmQDQ5tiYsI24r5lQfYb8vBOD46NgO"
        });
    }
}