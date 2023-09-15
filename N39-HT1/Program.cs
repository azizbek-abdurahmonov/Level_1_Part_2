using N39_HT1.Models;

var userAndWeathers = new List<object>
{
    new User("John", "Doe"),
    new User("Jonibek", "Aliyev"),
    new WeatherReport("Uzbekistan", 35),
    new User("Ahmad", "Abdurahmonov"),
    new WeatherReport("Russia", 29),
    new WeatherReport("USA", 37),
    new User("John", "Gishtmatov")
};

foreach (var obj in userAndWeathers)
{
    if (obj is User user && user is { FirstName: "John" })
    {
        Console.WriteLine(user);
    }
    else if (obj is WeatherReport weatherReport && weatherReport is { Degree: >= 30 })
    {
        Console.WriteLine(weatherReport);
    }
}