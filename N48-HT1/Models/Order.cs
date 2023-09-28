using FileBaseContext.Abstractions.Models.Entity;

namespace N48_HT1.Models;

public class Order : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public Guid UserId { get; set; }
}
