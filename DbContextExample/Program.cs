using DbContextExample.DataAccess;
using DbContextExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

var service = new ServiceCollection();

service.AddDbContext<IDbContext,AppDbContext>();

var provider = service.BuildServiceProvider();

var dbContext = provider.GetRequiredService<IDbContext>();

if (!dbContext.Authors.Any())
{
    dbContext.Authors.AddRange(new Author
    {
        FirstName = "John",
        LastName = "Doe"
    },
    new Author
    {
        FirstName = "Jane",
        LastName = "SurName"
    });

    var count = await dbContext.SaveChangesAsync();
}

if (dbContext.Authors.Any() && !dbContext.Books.Any())
{
    dbContext.Books.AddRange(
        new Book
        {
            Title = "iansainsian",
            Description = "inaisnaisnoan iansi ansia",
            AuthorId = dbContext.Authors.First().Id,
        },
        new Book
        {
            Title = "aisnaisnaisa",
            Description = "inasuanidnusds fib frwg nirwngi wrngu nwr",
            AuthorId = dbContext.Authors.Skip(1).First().Id
        }
        );

    await dbContext.SaveChangesAsync();
}

var allBooks = await dbContext.Books.Include(x => x.Author).ToListAsync();

Console.WriteLine(JsonSerializer.Serialize(allBooks));