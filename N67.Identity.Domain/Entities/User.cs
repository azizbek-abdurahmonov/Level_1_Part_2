namespace N67.Identity.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public ICollection<Course> TeacherCourses { get; set; }

    public ICollection<CourseStudent> CourseStudents { get; set; }
}