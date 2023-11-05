using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace N67.Identity.Persistence.EntityConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(course => course.Name).IsRequired().HasMaxLength(256);
        builder.Property(course => course.TeacherId).IsRequired();

        builder.HasOne(course => course.Teacher)
            .WithMany(user => user.TeacherCourses)
            .HasForeignKey(course => course.TeacherId);
    }
}
