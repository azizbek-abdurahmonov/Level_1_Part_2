using Bogus;
using Microsoft.EntityFrameworkCore;
using N66_HT1.Domain.Entities;
using N66_HT1.Persistence.DataAccess;

namespace N66_HT1.Persistence.SeedData;

public class EntityFakers
{
    public static Faker<User> GetUserFaker()
    {
        return new Faker<User>()
            .RuleFor(x => x.FirstName, s => s.Person.FirstName)
            .RuleFor(x => x.LastName, s => s.Person.LastName)
            .RuleFor(x => x.Email, s => s.Person.Email)
            .RuleFor(x => x.PasswordHash, s => Guid.NewGuid().ToString().ToUpper());
    }

    public static Faker<Book> GetBookFaker(AppDbContext dbContext)
    {
        return new Faker<Book>()
            .RuleFor(x => x.Title, s => s.Lorem.Word())
            .RuleFor(x => x.Description, s => s.Lorem.Text())
            .RuleFor(x => x.AuthorId, s => s.PickRandom(dbContext.Users.Select(user => user.Id).ToList()));
    }
}
