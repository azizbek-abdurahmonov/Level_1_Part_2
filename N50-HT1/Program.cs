using WebApplication1.Models.Entities;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var users = new List<User>
{
    new User("Alice", "Johnson", "alice.j@example.com"),
    new User("Bob", "Smith", "bob.smith@mailbox.net"),
    new User("Emily", "Davis", "emily.d@example.net"),
    new User("Michael", "Brown", "michael.b@example.org"),
    new User("Olivia", "Wilson", "olivia.w@mailbox.net"),
    new User("David", "Lee", "david.lee@example.com"),
    new User("Sophia", "Taylor", "sophia.t@mailbox.net"),
    new User("James", "Anderson", "james.a@example.org"),
    new User("Emma", "Robinson", "emma.r@example.com"),
    new User("William", "Martinez", "william.m@example.net"),
    new User("Ava", "Hernandez", "ava.h@mailbox.net"),
    new User("Daniel", "Garcia", "daniel.g@example.org"),
    new User("Mia", "Lopez", "mia.l@example.com"),
    new User("Benjamin", "Clark", "benjamin.c@example.net"),
    new User("Charlotte", "Hall", "charlotte.h@mailbox.net"),
    new User("Ethan", "White", "ethan.w@example.org"),
    new User("Isabella", "Young", "isabella.y@example.com"),
    new User("Samuel", "Turner", "samuel.t@mailbox.net"),
    new User("Avery", "Miller", "avery.m@example.net"),
    new User("Madison", "Wright", "madison.w@mailbox.net")
};

var random = new Random();
var orders = new List<Order>
{
    new Order(users[random.Next(0, users.Count)].Id, 5_678),
    new Order(users[random.Next(0, users.Count)].Id, 12_345),
    new Order(users[random.Next(0, users.Count)].Id, 8_765),
    new Order(users[random.Next(0, users.Count)].Id, 98_765),
    new Order(users[random.Next(0, users.Count)].Id, 3_210),
    new Order(users[random.Next(0, users.Count)].Id, 25_678),
    new Order(users[random.Next(0, users.Count)].Id, 56_789),
    new Order(users[random.Next(0, users.Count)].Id, 1_234),
    new Order(users[random.Next(0, users.Count)].Id, 7_890),
    new Order(users[random.Next(0, users.Count)].Id, 54_321),
    new Order(users[random.Next(0, users.Count)].Id, 23_456),
    new Order(users[random.Next(0, users.Count)].Id, 87_654),
    new Order(users[random.Next(0, users.Count)].Id, 6_789),
    new Order(users[random.Next(0, users.Count)].Id, 9_876),
    new Order(users[random.Next(0, users.Count)].Id, 32_109),
    new Order(users[random.Next(0, users.Count)].Id, 67_890),
    new Order(users[random.Next(0, users.Count)].Id, 43_210),
    new Order(users[random.Next(0, users.Count)].Id, 5_432),
    new Order(users[random.Next(0, users.Count)].Id, 78_901),
    new Order(users[random.Next(0, users.Count)].Id, 10_987),
    new Order(users[random.Next(0, users.Count)].Id, 9_321),
    new Order(users[random.Next(0, users.Count)].Id, 34_567),
    new Order(users[random.Next(0, users.Count)].Id, 76_543),
    new Order(users[random.Next(0, users.Count)].Id, 2_109),
    new Order(users[random.Next(0, users.Count)].Id, 4_321),
    new Order(users[random.Next(0, users.Count)].Id, 89_012),
    new Order(users[random.Next(0, users.Count)].Id, 1_987),
    new Order(users[random.Next(0, users.Count)].Id, 6_543),
    new Order(users[random.Next(0, users.Count)].Id, 87_901),
    new Order(users[random.Next(0, users.Count)].Id, 21_098),
    new Order(users[random.Next(0, users.Count)].Id, 10_321),
    new Order(users[random.Next(0, users.Count)].Id, 45_678),
    new Order(users[random.Next(0, users.Count)].Id, 78_901),
    new Order(users[random.Next(0, users.Count)].Id, 3_456),
    new Order(users[random.Next(0, users.Count)].Id, 98_765),
    new Order(users[random.Next(0, users.Count)].Id, 54_321),
    new Order(users[random.Next(0, users.Count)].Id, 8_901),
    new Order(users[random.Next(0, users.Count)].Id, 12_345),
    new Order(users[random.Next(0, users.Count)].Id, 65_432),
    new Order(users[random.Next(0, users.Count)].Id, 2_109),
    new Order(users[random.Next(0, users.Count)].Id, 43_210),
    new Order(users[random.Next(0, users.Count)].Id, 56_789),
    new Order(users[random.Next(0, users.Count)].Id, 9_876),
    new Order(users[random.Next(0, users.Count)].Id, 1_234),
    new Order(users[random.Next(0, users.Count)].Id, 76_543),
    new Order(users[random.Next(0, users.Count)].Id, 32_109),
    new Order(users[random.Next(0, users.Count)].Id, 23_456),
    new Order(users[random.Next(0, users.Count)].Id, 78_901),
    new Order(users[random.Next(0, users.Count)].Id, 10_987),
    new Order(users[random.Next(0, users.Count)].Id, 5_678),
    new Order(users[random.Next(0, users.Count)].Id, 12000),
};

builder.Services.AddSingleton<List<User>>(users);
builder.Services.AddSingleton<List<Order>>(orders);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserOrderService, UserOrderService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();