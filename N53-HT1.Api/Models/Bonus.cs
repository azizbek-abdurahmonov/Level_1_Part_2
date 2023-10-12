using N53_HT1.Api.Common;

namespace N53_HT1.Api.Models;

public class Bonus : IEntity
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public Guid UserId { get; set; }

    public Bonus(Guid id, int amount, Guid userId)
    {
        Id = id;
        Amount = amount;
        UserId = userId;
    }
}
