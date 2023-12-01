using Microsoft.EntityFrameworkCore;
using N76_HT1.Entities;

namespace N76_HT1.DbContexts;

public class IdentityDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();    

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }
}
