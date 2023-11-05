using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace N67.Identity.Persistence.EntityConfiguration;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.StudentId });

        builder.HasOne(x => x.Course).WithMany(x => x.CourseStudents).HasForeignKey(x => x.CourseId);

        builder.HasOne(x => x.Student).WithMany(x => x.CourseStudents).HasForeignKey(x => x.StudentId);
    }
}
