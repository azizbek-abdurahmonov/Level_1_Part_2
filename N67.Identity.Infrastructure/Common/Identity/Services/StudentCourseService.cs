using Identity.Domain.Entities;
using N67.Identity.Application.Common.Identity.Services;
using N67.Identity.Persistence.DataAccess;
using System.Linq.Expressions;

namespace N67.Identity.Infrastructure.Common.Identity.Services;

public class StudentCourseService : IStudentCourseService
{
    private readonly AppDbContext _dbContext;

    public StudentCourseService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<StudentCourse> CreateAsync(StudentCourse studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.StudentCourses.AddAsync(studentCourse);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return studentCourse;
    }

    public ValueTask<StudentCourse> DeleteAsync(StudentCourse studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default)
        => DeleteAsync(studentCourse.Id, saveChanges, cancellationToken);

    public async ValueTask<StudentCourse> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(id)
            ?? throw new InvalidOperationException("Stucent course not found!");

        _dbContext.StudentCourses.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;

    }

    public IQueryable<StudentCourse> Get(Expression<Func<StudentCourse, bool>>? predicate = null)
        => predicate != null ? _dbContext.StudentCourses.Where(predicate) : _dbContext.StudentCourses;

    public async ValueTask<StudentCourse?> GetByIdAsync(Guid id)
        => await _dbContext.StudentCourses.FindAsync(id);

    public async ValueTask<StudentCourse> UpdateAsync(StudentCourse studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(studentCourse.Id)
            ?? throw new InvalidOperationException("Student user not found!");

        found.StudentId = studentCourse.Id;
        found.CourseId = studentCourse.CourseId;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;

    }
}
