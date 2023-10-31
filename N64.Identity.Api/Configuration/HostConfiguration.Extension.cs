using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Application.Common.Notification.Services;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Infrastructure.Common.Identity.Services;
using N64.Identity.Infrastructure.Common.Notification.Services;
using System.Runtime.CompilerServices;
using System.Text;

namespace N64.Identity.Api.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
        builder.Services.Configure<VerificationTokenSettings>(builder.Configuration.GetSection(nameof(VerificationTokenSettings)));

        builder.Services.AddDataProtection();

        builder.Services
            .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
            .AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<IVerificationTokenGeneratorService, VerificationTokenGeneratorService>();

        builder.Services
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAuthService, AuthService>();


        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    ValidateLifetime = jwtSettings.ValidateLifetime,
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
        builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

        return builder;
    }


    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplication UseIdentityInfrastructure(this WebApplication app)
    {
        app.UseAuthentication().UseAuthorization();

        return app;
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
