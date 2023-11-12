using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71_HT1.Domain.Entities;

namespace N71_HT1.Persistence.EntitiesConfiguration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasOne(blog => blog.Author)
            .WithMany(user => user.BlogPosts)
            .HasForeignKey(blog => blog.AuthorId);
    }
}