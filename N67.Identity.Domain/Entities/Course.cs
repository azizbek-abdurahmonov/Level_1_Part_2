namespace N67.Identity.Domain.Entities;

public class Location
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public Guid TeacherId { get; set; }

    public virtual User Teacher { get; set; }

    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}
