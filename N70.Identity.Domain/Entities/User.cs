using N70.Identity.Domain.Common;

namespace N70.Identity.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string EmailAddress { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsEmailAddressVerified { get; set; } = false;
    
    public Guid RoleId { get; set; }
    
    public virtual Role Role { get; set; }
}