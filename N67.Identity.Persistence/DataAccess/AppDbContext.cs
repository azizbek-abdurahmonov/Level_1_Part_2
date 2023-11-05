using N67.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Identity.Domain.Entities;

namespace N67.Identity.Persistence.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Location> Courses => Set<Location>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<CourseStudent> StudentCourses => Set<CourseStudent>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}