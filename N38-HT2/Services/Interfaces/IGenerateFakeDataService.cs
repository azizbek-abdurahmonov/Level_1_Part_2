using N38_HT2.Models;

namespace N38_HT2.Services.Interfaces;

public interface IGenerateFakeDataService
{
    List<Employee> GenerateFakeEmployees(int count = 1);
    List<Order> GenerateFakeOrders(int count = 1);
    List<UserAddress> GenerateFakeUserAddresses(int count = 1);
    List<BlogPost> GenerateFakeBlogPosts(int count = 1);
    List<WeatherReport> GenerateFakeWeatherReports(int count = 1);

}
