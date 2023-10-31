using DbContextExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextExample.DataAccess;

public interface IDbContext
{
    DbSet<Author> Authors { get; }

    DbSet<Book> Books { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellation = default);
}
