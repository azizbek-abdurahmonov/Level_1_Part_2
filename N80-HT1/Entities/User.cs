using N80_HT1.Common.Models;

namespace N80_HT1.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}
