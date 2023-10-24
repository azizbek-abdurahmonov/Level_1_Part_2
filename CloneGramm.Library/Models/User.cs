using CloneGramm.Library.Common;

namespace CloneGramm.Library.Models;

public class User : SoftDeletedEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? ProfileImagePath { get; set; }
}
