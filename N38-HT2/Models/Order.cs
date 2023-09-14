namespace N38_HT2.Models;

public class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public DateOnly OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, CustomerId: {CustomerId}, OrderDate: {OrderDate}, Amount: {TotalAmount}, Status: {Status}";
    }
}