using Microsoft.EntityFrameworkCore;
using N71_HT1.Domain.Entities;

namespace N71_HT1.Persistence.DataContexts;

public class BlogPostsDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Blog> Blogs => Set<Blog>();

    public DbSet<Comment> Comments => Set<Comment>();

    public BlogPostsDbContext(DbContextOptions<BlogPostsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogPostsDbContext).Assembly);
    }
}