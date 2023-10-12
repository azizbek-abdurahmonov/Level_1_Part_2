using N53_HT1.Api.Common;

namespace N53_HT1.Api.Models;

public class Order : IEntity
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public Guid UserId { get; set; }

    public Order(Guid id, int amount, Guid userId)
    {
        Id = id;
        Amount = amount;
        UserId = userId;
    }
}
