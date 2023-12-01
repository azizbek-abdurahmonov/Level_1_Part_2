namespace N76_HT1.Models.Common;

public interface IModificationAuditableEntity
{
    Guid? ModifiedByUserId { get; set; }
}
