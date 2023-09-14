namespace N38_HT2.Models;

public class UserAddress
{
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }

    public override string ToString()
    {
        return $"Country : {Country}, State: {State}, City: {City}, Street: {Street}, Number: {Number}";
    }
}