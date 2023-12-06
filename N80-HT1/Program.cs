using Microsoft.EntityFrameworkCore;
using N80_HT1.Caching;
using N80_HT1.Caching.Interfaces;
using N80_HT1.DbContexts;
using N80_HT1.Repositories;
using N80_HT1.Repositories.Interfaces;
using N80_HT1.Services;
using N80_HT1.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));
builder.Services.AddSingleton<ICacheBroker, RedisCacheBroker>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "N80-HT-1-Cache";

    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();
app.MapControllers();

await app.RunAsync();