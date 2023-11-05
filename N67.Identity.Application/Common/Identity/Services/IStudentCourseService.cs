using N67.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N67.Identity.Application.Common.Identity.Services;

public interface ICourseStudentService
{
    IQueryable<CourseStudent> Get(Expression<Func<CourseStudent, bool>>? predicate = null);

    ValueTask<CourseStudent?> GetByIdAsync(Guid id);

    ValueTask<CourseStudent> CreateAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default);
                                                       
    ValueTask<CourseStudent> UpdateAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default);
                                                       
    ValueTask<CourseStudent> DeleteAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<CourseStudent> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}
