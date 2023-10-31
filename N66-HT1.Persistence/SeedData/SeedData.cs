using N66_HT1.Persistence.DataAccess;

namespace N66_HT1.Persistence.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeSeedData(this AppDbContext dbContext)
    {
        if (!dbContext.Users.Any())
            await AddUsers(dbContext, 20);

        if (!dbContext.Books.Any())
            await AddBooks(dbContext, 50);
    }

    private static async ValueTask<int> AddUsers(AppDbContext dbContext, int count)
    {
        await dbContext.Users.AddRangeAsync(EntityFakers.GetUserFaker().Generate(count));
        return await dbContext.SaveChangesAsync();
    }


    private static async ValueTask<int> AddBooks(AppDbContext dbContext, int count)
    {
        await dbContext.Books.AddRangeAsync(EntityFakers.GetBookFaker(dbContext).Generate(count));
        return await dbContext.SaveChangesAsync();
    }
}
