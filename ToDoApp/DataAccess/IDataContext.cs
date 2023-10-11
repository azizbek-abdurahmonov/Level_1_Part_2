using FileBaseContext.Abstractions.Models.FileSet;
using ToDoApp.Models;

namespace ToDoApp.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<ToDo, Guid> ToDos { get; }
    ValueTask SaveChangesAsync();
}