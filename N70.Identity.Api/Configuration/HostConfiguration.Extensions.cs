using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Notifications.Services;
using N70.Identity.Application.Common.Settings;
using N70.Identity.Infrastructure.Common.Identity.Services;
using N70.Identity.Infrastructure.Common.Notifications.Services;
using N70.Identity.Persistence.DataContexts;
using N70.Identity.Persistence.Repositories;
using N70.Identity.Persistence.Repositories.Interfaces;

namespace N70.Identity.Api.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        return builder;
    }
    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        //Configurations
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
        builder.Services.Configure<VerificationTokenSettings>(
            builder.Configuration.GetSection(nameof(VerificationTokenSettings)));

        builder.Services.AddDataProtection();
        
        //Transient (helper) services
        builder.Services
            .AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
            .AddTransient<IVerificationTokenGeneratorService, VerificationTokenGeneratorService>();

        //scope services~
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>();

        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IRoleService, RoleService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAuthService, AuthService>();

        //
        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey
                };
            });

        return builder;
    }

    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));

        builder.Services.AddScoped<IEmailOrchestrationService, EmailOrchestrationService>();

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


    private static WebApplication UseIdentityInfrastructure(this WebApplication app)
    {
        app
            .UseAuthentication()
            .UseAuthorization();

        return app;
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