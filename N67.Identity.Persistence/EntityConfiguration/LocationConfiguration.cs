using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace N67.Identity.Persistence.EntityConfiguration;

public class LocationConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(location => location.Name).IsRequired().HasMaxLength(512);
        builder.Property(location => location.Type).IsRequired();
    }
}
