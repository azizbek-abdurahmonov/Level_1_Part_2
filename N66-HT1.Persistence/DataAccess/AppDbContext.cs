using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using N66_HT1.Application.Common.Settings;
using N66_HT1.Domain.Entities;

namespace N66_HT1.Persistence.DataAccess;

public class AppDbContext : DbContext
{
    //private readonly DbSettings _dbSettings;

    //public AppDbContext(IOptions<DbSettings> settings)
    //{
    //    _dbSettings = settings.Value;
    //}

    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Book> Books => Set<Book>();
}
