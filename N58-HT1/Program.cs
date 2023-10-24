var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(config =>
//    {
//        config.AllowAnyHeader();
//        config.AllowAnyMethod();
//        config.AllowAnyOrigin();
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.MapControllers();

await app.RunAsync();
