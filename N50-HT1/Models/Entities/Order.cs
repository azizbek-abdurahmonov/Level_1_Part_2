namespace WebApplication1.Models.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }

    public Order(Guid userId, decimal amount)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Amount = amount;
    }
}