using Microsoft.EntityFrameworkCore;
using N64.Identity.Domain.Entity;

namespace N64.Identity.Persistence.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=IdentityDB;Username=postgres;Password=postgres");
    }
}
