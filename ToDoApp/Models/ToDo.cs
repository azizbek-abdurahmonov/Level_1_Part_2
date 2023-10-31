using ToDoApp.Common;

namespace ToDoApp.Models;

public class ToDo : SoftDeletedEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDone { get; set; }
    public Guid UserId { get; set; }

    public ToDo()
    {
        
    }

    public ToDo(string name, string description, DateTime createdAt, bool isDone, Guid userId)
    {
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        IsDone = isDone;
        UserId = userId;
    }
}