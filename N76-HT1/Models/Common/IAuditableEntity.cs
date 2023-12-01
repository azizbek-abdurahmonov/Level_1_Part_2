namespace N76_HT1.Models.Common;

public interface IAuditableEntity : IEntity
{
    DateTime CreatedTime { get; set; }

    DateTime? ModifiedTime { get; set; }
}
