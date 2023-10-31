using FileBaseContext.Abstractions.Models.Entity;

namespace ToDoApp.Common;

public interface IEntity : IFileSetEntity<Guid>
{
}
