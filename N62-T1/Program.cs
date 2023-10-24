using N62_T1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);


var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app.MapControllers();

await app.RunAsync();