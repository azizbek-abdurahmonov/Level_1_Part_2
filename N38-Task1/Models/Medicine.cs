namespace N38_Task1.Models;

public class Medicine
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Medicine(Guid id, string name, decimal price, DateTime expirationDate, int count, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        ExpirationDate = expirationDate;
        Count = count;
        Description = description;
        CreatedAt = DateTime.Now;
        UpdatedAt = default(DateTime);
    }
}