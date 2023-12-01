namespace N76_HT1.Models.Common;

public interface ISoftDeletedEntity
{
    bool IsDeleted { get; set; }
    DateTime? DeletedTime { get; set; }
}
