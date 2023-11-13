using Microsoft.EntityFrameworkCore;
using N71_HT1.Application.Common.BlogPosts.Services;
using N71_HT1.Infrastructure.Common.BlogPosts.Services;
using N71_HT1.Persistence.DataContexts;
using N71_HT1.Persistence.Repositories;
using N71_HT1.Persistence.Repositories.Interfaces;

namespace N71_HT1.Api.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddBlogPostsInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BlogPostsDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IBlogRepository, BlogRepository>()
            .AddScoped<ICommentRepository, CommentRepository>();

        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IBlogService, BlogService>()
            .AddScoped<ICommentService, CommentService>()
            .AddScoped<IBloggerService, BloggerService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}
