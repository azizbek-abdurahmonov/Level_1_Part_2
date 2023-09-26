using N45_HT1.Models;
using System.Text.Json;

var random = new Random();


var users = new List<User>
{
    new User("Azizbek"),
    new User("Abdura"),
};

var orders = new List<Order>
{
    new Order(15000, users[random.Next(users.Count)].Id),
    new Order(52424, users[random.Next(users.Count)].Id),
    new Order(14152, users[random.Next(users.Count)].Id),
    new Order(142525, users[random.Next(users.Count)].Id),
    new Order(1501400, users[random.Next(users.Count)].Id),
    new Order(14151415, users[random.Next(users.Count)].Id),
    new Order(15114400, users[random.Next(users.Count)].Id),
};

var products = new List<Product>
{
    new Product("Pc", 1345),
    new Product("Laptop", 1241),
    new Product("Hp", 4141),
    new Product("Acer", 2433),
    new Product("Asus", 1200),
    new Product("Rasberry", 500),
    new Product("Mac", 10250),
};

var orderProducts = new List<OrderProduct>
{
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,12),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,141),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,14),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,434),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,55),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,65),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,76),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,6412),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,5),
};

var userId = users[random.Next(users.Count)].Id;

var query =
    from user in users
    join order in orders on user.Id equals order.UserId
    join orderProduct in orderProducts on order.Id equals orderProduct.OrderId
    join product in products on orderProduct.ProductId equals product.Id
    where user.Id == userId
    select product.Name;

query.ToList().ForEach(Console.WriteLine);