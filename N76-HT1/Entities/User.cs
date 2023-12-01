using N76_HT1.Models.Common;

namespace N76_HT1.Entities;

public class User : AuditableEntity, ICreationAuditableEntity, IDeletionAuditableEntity, IModificationAuditableEntity
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public Guid? ModifiedByUserId { get; set; }

    public Guid? DeletedByUserId { get; set; }

    public Guid CreatedByUserid { get; set; }
}
