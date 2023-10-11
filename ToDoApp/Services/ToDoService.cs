using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ToDoApp.DataAccess;
using ToDoApp.Models;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services;

public class ToDoService : ITodoService
{
    private IDataContext _context;

    public ToDoService(IDataContext context)
    {
        _context = context;
    }

    public IQueryable<ToDo> Get(Expression<Func<ToDo, bool>> predicate)
        => _context.ToDos.Where(predicate.Compile()).AsQueryable();


    public ValueTask<ICollection<ToDo>> GetAsync(IEnumerable<Guid> ids)
    {
        return new ValueTask<ICollection<ToDo>>(_context.ToDos.Where(x => ids.Contains(x.Id)).ToList());
    }

    public ValueTask<ToDo?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        return _context.ToDos.FindAsync(id);
    }

    public async ValueTask<ToDo> CreateAsync(ToDo toDo, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        ToValidate(toDo);

        await _context.ToDos.AddAsync(toDo, cancellationToken);

        if (saveChanges)
            await _context.SaveChangesAsync();
        return toDo;
    }

    public async ValueTask<ToDo> UpdateAsync(ToDo toDo, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        ToValidate(toDo);
        
        var found = await _context.ToDos.FindAsync(toDo.Id, cancellationToken);

        found.Name = toDo.Name;
        found.Description = toDo.Description;
        found.IsDone = toDo.IsDone;

        await _context.ToDos.UpdateAsync(found, cancellationToken);

        if (saveChanges)
            await _context.SaveChangesAsync();

        return found;
    }

    public ValueTask<ToDo> DeleteAsync(ToDo toDo, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(toDo.Id, saveChanges, cancellationToken);
    }

    public async ValueTask<ToDo> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var found = await _context.ToDos.FindAsync(id);

        if (found.IsDeleted)
            throw new Exception("Todo already deleted!");

        await _context.ToDos.RemoveAsync(found, cancellationToken);
        
        if(saveChanges)
            await _context.SaveChangesAsync();

        return found;
    }

    private void ToValidate(ToDo toDo)
    {
        if (string.IsNullOrWhiteSpace(toDo.Name) || string.IsNullOrWhiteSpace(toDo.Description))
            throw new ValidationException("Invalid name or description !");
    }
}