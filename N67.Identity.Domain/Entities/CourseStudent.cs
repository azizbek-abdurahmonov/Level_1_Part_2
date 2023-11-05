namespace N67.Identity.Domain.Entities;

public class CourseStudent
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }

    public virtual User Student { get; set; }

    public virtual Course Course { get; set; }
}