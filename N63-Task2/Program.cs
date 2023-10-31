using N63_Task2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<PasswordHasherService>();
builder.Services.AddScoped<TokenGeneratorService>();

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();


app.MapControllers();

app.Run();
