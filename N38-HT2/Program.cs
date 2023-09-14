using N38_HT2.Services;

var faker = new GenerateFakeDataService();

var employees = faker.GenerateFakeEmployees(10);
var orders = faker.GenerateFakeOrders(15);
var addresses = faker.GenerateFakeUserAddresses(20);
var blogPosts = faker.GenerateFakeBlogPosts(5);
var weatherReports = faker.GenerateFakeWeatherReports(15);

// employees.ForEach(Console.WriteLine);
// orders.ForEach(Console.WriteLine);
// addresses.ForEach(Console.WriteLine);
// blogPosts.ForEach(Console.WriteLine);
weatherReports.ForEach(Console.WriteLine);