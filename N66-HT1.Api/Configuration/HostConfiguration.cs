using System.Runtime.CompilerServices;

namespace N66_HT1.Api.Configuration;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddDevTools()
            .AddDbManagerInfrastructure()
            .AddExposers();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .InitializeSeedData()
            //.ApplyMigrations()
            .UseDbManagerInfrastructue()
            .UseExposers();

        return new(app);
    }
}
