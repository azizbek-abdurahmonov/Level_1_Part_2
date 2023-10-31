using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using N66_HT1.Application.Common.DbManager.Services;
using N66_HT1.Application.Common.Settings;
using N66_HT1.Infrastructure.Common.DbManager.Services;
using N66_HT1.Persistence.DataAccess;
using N66_HT1.Persistence.SeedData;
using System.Runtime.CompilerServices;
using System.Text;

namespace N66_HT1.Api.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder
            .Services.AddSwaggerGen()
            .AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddDbManagerInfrastructure(this WebApplicationBuilder builder)
    {
        //configurations
        builder.Services.Configure<DbSettings>(builder.Configuration.GetSection(nameof(DbSettings)));
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

        var dbSettings = new DbSettings();
        builder.Configuration.GetSection(nameof(DbSettings)).Bind(dbSettings);

        //builder.Services.AddDbContext<AppDbContext>();

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(dbSettings.ConnectionString);
        });

        //helper services
        builder.Services
            .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
            .AddTransient<IPasswordHasherService, PasswordHasherService>();

        //services
        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IBookService, BookService>()
            .AddScoped<IAuthService, AuthService>();


        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey
                };
            });



        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.Services.AddControllers();

        return builder;
    }


    private static WebApplication InitializeSeedData(this WebApplication app)
    {
        app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>().InitializeSeedData().AsTask().Wait();
        return app;
    }

    private static WebApplication UseDbManagerInfrastructue(this WebApplication app)
    {
        app.UseAuthentication()
            .UseAuthorization();

        return app;
    }


    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger()
            .UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    //private static WebApplication ApplyMigrations(this WebApplication app)
    //{
    //    var provider = app.Services.CreateScope().ServiceProvider;

    //    var dbContext = provider.GetRequiredService<AppDbContext>();

    //    dbContext.Database.Migrate();

    //    return app;
    //}
}
