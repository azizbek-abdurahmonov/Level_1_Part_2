namespace N76_HT1.Configuration;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddDevTools().AddPersistence().AddIdentityInfrastructure().AddExposers();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseDevTools().UseExposers();

        return new(app);
    }
}
