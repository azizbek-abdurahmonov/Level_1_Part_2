using System.Linq.Expressions;
using ToDoApp.Models;

namespace ToDoApp.Services.Interfaces;

public interface ITodoService
{
    IQueryable<ToDo> Get(Expression<Func<ToDo, bool>> predicate);
    
    ValueTask<ICollection<ToDo>> GetAsync(IEnumerable<Guid> ids);

    ValueTask<ToDo?> GetByIdAsync(Guid id, CancellationToken cancellation = default);

    ValueTask<ToDo> CreateAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<ToDo> UpdateAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<ToDo> DeleteAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<ToDo> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}