using Bogus;
using N38_HT2.Models;
using N38_HT2.Services.Interfaces;

namespace N38_HT2.Services;

public class GenerateFakeDataService : IGenerateFakeDataService
{
    public List<Employee> GenerateFakeEmployees(int count = 1)
    {
        return new Faker<Employee>()
            .RuleFor(selector => selector.Id, Guid.NewGuid)
            .RuleFor(selector => selector.Name, faker => faker.Name.FullName())
            .RuleFor(selector => selector.Department, faker => faker.Company.CompanyName())
            .RuleFor(selector => selector.Salary, faker => faker.Random.Decimal(1_000, 10_000))
            .Generate(count);
    }

    public List<Order> GenerateFakeOrders(int count = 1)
    {
        var orders = new Faker<Order>()
            .RuleFor(selector => selector.Id, Guid.NewGuid)
            .RuleFor(selector => selector.OrderDate, faker => faker.Date.PastDateOnly())
            .RuleFor(selector => selector.TotalAmount, faker => faker.Random.Decimal(1_000_000, 15_000_000))
            .RuleFor(selector => selector.Status,
                faker => faker.PickRandom(new string[]
                    { "qabul qilindi", "yetkazildi", "bekor qilindi", "boshlandi" })).Generate(count);

        var random = new Random();
        var ids = orders.Select(order => order.Id).ToList();

        foreach (var order in orders)
        {
            order.CustomerId = ids[random.Next(0, orders.Count)];
        }

        return orders;
    }

    public List<UserAddress> GenerateFakeUserAddresses(int count = 1)
    {
        return new Faker<UserAddress>()
            .RuleFor(selector => selector.Country, faker => faker.Address.Country())
            .RuleFor(selector => selector.State, faker => faker.Address.State())
            .RuleFor(selector => selector.City, faker => faker.Address.City())
            .RuleFor(selector => selector.Street, faker => faker.Address.StreetName())
            .RuleFor(selector => selector.Number, faker => faker.Random.Int(0, 100))
            .Generate(count);
    }

    public List<BlogPost> GenerateFakeBlogPosts(int count = 1)
    {
        return new Faker<BlogPost>()
            .RuleFor(s => s.Id, Guid.NewGuid)
            .RuleFor(s => s.Title, f => f.Lorem.Paragraph())
            .RuleFor(s => s.Content, f => f.Lorem.Text())
            .RuleFor(s => s.ReadTime, f => f.Random.Int(2, 15))
            .RuleFor(s => s.CreatedDate, f => f.Date.PastDateOnly())
            .Generate(count);
    }

    public List<WeatherReport> GenerateFakeWeatherReports(int count = 1)
    {
        return new Faker<WeatherReport>()
            .RuleFor(s => s.Location, f => f.Address.Country())
            .RuleFor(s => s.Date, f => f.Date.FutureDateOnly())
            .RuleFor(s => s.Temperature, f => f.Random.Int(20, 60))
            .RuleFor(s => s.Humidity, f => f.Random.Int(0, 100))
            .RuleFor(s => s.WindSpeed, f => f.Random.Double(0, 100))
            .Generate(count);
    }
}