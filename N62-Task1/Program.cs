var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    var message = $"{DateTime.Now:u} request path = {context.Request.Path} with method {context.Request.Method}";

    var logFilePath = Path.Combine(builder.Environment.ContentRootPath, "log.txt");

    await using var fileStream = File.Open(logFilePath, FileMode.Append, FileAccess.Write);
    await using var streamWriter = new StreamWriter(fileStream);

    await streamWriter.WriteLineAsync(message);

    await next();
});

app.MapGet("/", () => "Hello World!");

app.Run();
