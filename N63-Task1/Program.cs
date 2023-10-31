using N63_Task1.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
   return DateTime.Now.ToString();
});

app.Use(async (context, next) =>
{
    await next();
});

app.UseMiddleware<CultureMiddleware>();     

app.Run();
