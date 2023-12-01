namespace N76_HT1.Models.Common;

public interface IDeletionAuditableEntity
{
    Guid? DeletedByUserId { get; set; }
}
