namespace N45_HT1.Models;

public class Order
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public Guid UserId { get; set; }

    public Order(decimal amount, Guid userId)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        UserId = userId;
    }
}
