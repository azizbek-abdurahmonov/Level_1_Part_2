using Microsoft.EntityFrameworkCore;
using N67.Identity.Application.Common.Identity.Services;
using N67.Identity.Infrastructure.Common.Identity.Services;
using N67.Identity.Persistence.DataAccess;

namespace N67.Identity.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<ILocationService, CourseService>()
            .AddScoped<ILocationService, LocationService>()
            .AddScoped<IRoleService, RoleService>()
            .AddScoped<IStudentCourseService, StudentCourseService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserSettingsService, UserSettingsService>();

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        return builder;
    }


    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

        return builder;
    }


    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.Services.AddControllers();

        return builder;
    }


    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger().UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}
