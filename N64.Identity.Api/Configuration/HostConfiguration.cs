using System.Runtime.CompilerServices;

namespace N64.Identity.Api.Configuration;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddDevTools()
            .AddIdentityInfrastructure()
            .AddNotificationInfrastructure()
            .AddExposers();

        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposers()
            .UseIdentityInfrastructure();

        return new ValueTask<WebApplication>(app);
    }
}