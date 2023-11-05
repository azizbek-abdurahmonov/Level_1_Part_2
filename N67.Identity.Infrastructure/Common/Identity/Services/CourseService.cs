using Identity.Domain.Entities;
using N67.Identity.Application.Common.Identity.Services;
using N67.Identity.Persistence.DataAccess;
using System.Linq.Expressions;

namespace N67.Identity.Infrastructure.Common.Identity.Services;

public class CourseService : ICourseService
{
    private readonly AppDbContext _dbContext;

    public CourseService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Course> CreateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.Courses.AddAsync(course, cancellationToken);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return course;
    }

    public ValueTask<Course> DeleteAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
        => DeleteAsync(course.Id, saveChanges, cancellationToken);

    public async ValueTask<Course> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(id)
            ?? throw new InvalidOperationException("Course not found!");

        _dbContext.Courses.Remove(found);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }

    public IQueryable<Course> Get(Expression<Func<Course, bool>>? predicate = null)
        => predicate != null ? _dbContext.Courses.Where(predicate) : _dbContext.Courses;

    public async ValueTask<Course?> GetByIdAsync(Guid id)
        => await _dbContext.Courses.FindAsync(id);

    public async ValueTask<Course> UpdateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(course.Id)
            ?? throw new InvalidOperationException("Course not found!");

        found.Name = course.Name;
        found.TeacherId = course.TeacherId;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return found;
    }
}
