using Microsoft.EntityFrameworkCore;
using N76_HT1.DbContexts;
using N76_HT1.Interceptors;
using N76_HT1.Repositories;
using N76_HT1.Repositories.Interfaces;
using N76_HT1.Services;
using N76_HT1.Services.Interfaces;

namespace N76_HT1.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen()
            .AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<UpdatePrimaryKeyInterceptor>()
            .AddScoped<UpdateAuditableInterceptor>()
            .AddScoped<UpdateSoftDeletedInterceptor>();

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IdentityDbContext>((provider, options) =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

            options.AddInterceptors(
                provider.GetRequiredService<UpdatePrimaryKeyInterceptor>(),
                provider.GetRequiredService<UpdateAuditableInterceptor>(),
                provider.GetRequiredService<UpdateSoftDeletedInterceptor>());
        });

        builder.Services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }


    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger()
            .UseSwaggerUI();

        return app;
    }
}
