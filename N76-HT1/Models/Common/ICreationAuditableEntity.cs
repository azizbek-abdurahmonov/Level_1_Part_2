namespace N76_HT1.Models.Common;

public interface ICreationAuditableEntity
{
    Guid CreatedByUserid { get; set; }
}
